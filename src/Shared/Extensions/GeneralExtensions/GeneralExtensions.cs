using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Shared.Extensions.GeneralExtensions
{
    [Serializable]
    public static class GeneralExtensions
    {
        public static string Indent = "\t";

        public static string RenderProperties<T>(this T source, string indent = "\t")
            where T : class
        {
            //return string.Empty;
            try
            {
                if (source == null) return string.Empty;
                indent = Indent;
                indent = indent ?? string.Empty;
                var builder = new StringBuilder();

                if (indent == "\t")
                    builder.AppendLine();

                var properties = GetAccessibleProperties(source);

                foreach (var property in properties)
                {
                    RenderProperty(property, source, builder, indent);
                }

                return builder.ToString();

            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static IEnumerable<PropertyInfo> GetAccessibleProperties(object source)
        {
            try
            {
                //Debug.Assert(source != null);
                // optimized for readibility over performance ->
                var properties = source.GetType()
                    .GetProperties(
                          BindingFlags.Instance             // only instance properties
                        | BindingFlags.Public)              // publicly accessible only
                    .Where(x =>
                           x.CanRead                             // must have getter
                        && x.GetGetMethod(false) != null         // must have public getter
                        && x.GetIndexParameters().Length == 0
                        && x.PropertyType.IsInterface == false);  // must not be an indexer
                return properties;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Enumerable.Empty<PropertyInfo>();
            }
        }

        private static void RenderProperty(
            PropertyInfo property, object parent, StringBuilder builder, string indent)
        {
            //Debug.Assert(property != null);
            //Debug.Assert(parent != null);
            //Debug.Assert(builder != null);
            //Debug.Assert(indent != null);
            try
            {
                var name = property.Name;
                if (name == "Capacity")
                    return;

                var value = property.GetValue(parent, null); // <- need to handle exception?

                if (value == null)
                {
                    if (Indent == "\t")
                        builder.AppendLine($"{indent}{name}: ");
                    else
                        builder.Append($"{indent}{name}: ");
                }
                else if (value.GetType().IsValueType || value is string)
                {
                    if (Indent == "\t")
                        builder.AppendLine($"{indent}{name}: {value}");
                    else
                        builder.Append($"{indent}{name}: {value}");
                }
                else
                {
                    if (property.PropertyType.Namespace == "System.Collections.Generic")
                    {
                        if (value != null)
                        {
                            var result = string.Empty;
                            if (value is List<Guid>)
                            {
                                var GuidList = (List<Guid>)value;
                                for (int i = 0; i < GuidList.Count; i++)
                                {
                                    result += "[" + string.Join(", ", GuidList[i]) + "]";
                                }
                                if (Indent == "\t")
                                    builder.AppendLine($"{indent}{name}: {result}");
                                else
                                    builder.Append($"{indent}{name}: {result}");
                            }
                        }
                    }
                    else
                    {
                        builder.Append(value.RenderProperties(indent + indent));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string NameOf<T>(Expression<Func<T>> propExp)
        {
            var memberExpression = propExp.Body as MemberExpression;
            return memberExpression != null ? memberExpression.Member.Name : null;
        }

        public static string NameOf<TObj, T>(Expression<Func<TObj, T>> propExp)
        {
            var memberExpression = propExp.Body as MemberExpression;
            return memberExpression != null ? memberExpression.Member.Name : null;
        }

        public static string Base64Encode(this string text)
        {
            try
            {
                var textBytes = Encoding.UTF8.GetBytes(text);
                return Convert.ToBase64String(textBytes);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string Base64Decode(this string base64)
        {
            try
            {
                if (string.IsNullOrEmpty(base64))
                    return string.Empty;
                var base64Bytes = Convert.FromBase64String(base64);
                return Encoding.UTF8.GetString(base64Bytes);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}