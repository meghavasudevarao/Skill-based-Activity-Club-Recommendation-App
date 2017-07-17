using System.Web.Http;
using WebActivatorEx;
using ClubNYITServices;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ClubNYITServices
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration

                .EnableSwagger(c => { c.SingleApiVersion("v1", "ClubNYITServices");
                    c.IncludeXmlComments(string.Format(@"{0}bin\ClubNYITServices.XML", AppDomain.CurrentDomain.BaseDirectory)); })

                .EnableSwaggerUi();
                
                }
        private static string GetXmlCommentsPath()
        {
            var path = String.Format(@"{0}bin\Services.XML", AppDomain.CurrentDomain.BaseDirectory);
            return path;
        }
    }
}
