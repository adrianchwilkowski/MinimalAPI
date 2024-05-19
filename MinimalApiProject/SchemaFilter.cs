using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MinimalApiProject.Infrastructure.Commands;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApiProject
{
    public class SchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context == null || context.MemberInfo == null)
            {
                return;
            }
            if (context.Type == typeof(string) && context.MemberInfo.Name == "DataUrodzenia")
            {
                schema.Example = new OpenApiString("dd-mm-yyyy");
            }
        }
    }
}
