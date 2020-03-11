using System.Globalization;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using WebActivatorEx;
using FitnessApp;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FitnessApp
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    { 
                        c.SingleApiVersion("v1", "FitnessApp");
                        c.OperationFilter<IncludeParameterNamesInOperationIdFilter>();
                    });
        }
    }

    internal class IncludeParameterNamesInOperationIdFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters != null)
            {
                var parameters = operation.parameters.Select(
                    p => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(p.name));
                operation.operationId = string.Format("{0}By{1}", operation.operationId, string.Join("And", parameters));
            }
        }
    }
}