using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace WebAPI.Config
{
    // Classe responsavel por configurações do swagger
    public static class ConfigSwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api-Teste",
                        Version = "v1",
                        Description = "Api",
                        Contact = new OpenApiContact
                        {
                            Name = "Richard Bomfim",
                            Url = new Uri("https://www.linkedin.com/in/richard-bomfim-84317261/")
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Documentação API da Prova";
                c.SwaggerEndpoint("v1/swagger.json", "v1");
                c.OAuthClientId("swagger-dash");
                c.OAuthAppName("Swagger Dashboard");
                c.EnableFilter();
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.List);
                c.EnableDeepLinking();
                c.RoutePrefix = "swagger";
            });
        }
    }

}
