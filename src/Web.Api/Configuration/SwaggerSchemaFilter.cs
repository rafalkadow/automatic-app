using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;

namespace Web.Api.Configuration
{
    internal class SwaggerSchemaFilter : Swashbuckle.AspNetCore.SwaggerGen.ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Properties = schema.Properties
                .OrderBy(x => string.IsNullOrWhiteSpace(x.Value.Type) ? "z" : "a")
                .ToDictionary(p2 => p2.Key, p2 => p2.Value);
        }
    }
}
