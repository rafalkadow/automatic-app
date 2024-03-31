using Shared.Interfaces.Serialization.Options;
using System.Text.Json;

namespace Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}