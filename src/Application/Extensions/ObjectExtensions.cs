using System.Reflection;

namespace Application.Extensions
{
    public static class ObjectExtensions
    {
        private static T ObjectFromDictionary<T>(IDictionary<string, object> dict) where T : class
        {
            Type type = typeof(T);
            T result = (T)Activator.CreateInstance(type);
            foreach (var item in dict)
            {
                type.GetProperty(item.Key).SetValue(result, item.Value, null);
            }
            return result;
        }

        public static IDictionary<string, string> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            Type myObjectType = source.GetType();
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var indexer = new object[0];
            PropertyInfo[] properties = myObjectType.GetProperties();
            foreach (var info in properties)
            {
                var value = info.GetValue(source, indexer);
                if (value != null)
                    dict.Add(info.Name, value.ToString());
            }
            return dict;
        }
    }
}