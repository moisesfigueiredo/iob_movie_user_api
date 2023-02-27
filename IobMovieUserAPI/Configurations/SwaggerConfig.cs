using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Xml.Serialization;

namespace IobMovieUserAPI.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "REST API - IOB",
                        Version = "v1",
                        Description = "Movies data and User Login"
                    });
            });
        }
    }
}
