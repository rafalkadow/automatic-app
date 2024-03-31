using Newtonsoft.Json;
using Shared.Interfaces.Serialization.Settings;

namespace Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}