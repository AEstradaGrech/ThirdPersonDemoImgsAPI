using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThirdPersonDemoIMGs.Services;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsInfrasturcture.Context;
using ThirdPersonDemoIMGsInfrasturcture.Repositories;

namespace ThirdPersonDemoIMGs.StartupConfigurationExtensions
{
    public static class StartupConfigurationExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IImageMgmtService, ImageMgmtService>();
            services.AddScoped<IImageMapperService, ImageMapperService>();
            services.AddScoped<IImagesRepository, ImagesRepository>();

            return services;
        }

        public static IApplicationBuilder ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetail()
                        {

                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error. Trace :: {contextFeature.Error}"

                        }.ToString());
                    }
                });
            });

            return app;
        }

        public static IApplicationBuilder ManageMigrations(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                }

                
            }

            return app;
        }
    }
}
