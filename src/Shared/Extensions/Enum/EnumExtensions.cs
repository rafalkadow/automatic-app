using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Shared.Extensions.EnumExtensions
{
    [Serializable]
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = null;
            try
            {
                if (e is Enum)
                {
                    Type type = e.GetType();
                    Array values = Enum.GetValues(type);

                    foreach (int val in values)
                    {
                        if (val == e.ToInt32(CultureInfo.InvariantCulture))
                        {
                            var memInfo = type.GetMember(type.GetEnumName(val));
                            var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if (descriptionAttributes.Length > 0)
                            {
                                // we're only getting the first description we find
                                // others will be ignored
                                description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return description;
        }

        public static T GetEnumValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException();
            FieldInfo[] fields = type.GetFields();
            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a })
                            .Where(a => ((DescriptionAttribute)a.Att)
                                .Description == description).SingleOrDefault();
            return field == null ? default : (T)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            if (!Enum.TryParse(typeof(T), value, true, out object result))
                return default;
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }
    }
}