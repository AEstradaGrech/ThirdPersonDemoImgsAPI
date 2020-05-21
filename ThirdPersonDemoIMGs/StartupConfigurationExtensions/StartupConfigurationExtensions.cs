using System;
using System.Net;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThirdPersonDemoIMGs.Services;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.Dtos;
using ThirdPersonDemoIMGsDomain.IRepositories;
using ThirdPersonDemoIMGsDomain.Specifications;
using ThirdPersonDemoIMGsInfrasturcture.Context;
using ThirdPersonDemoIMGsInfrasturcture.Helpers;
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
            services.AddScoped<ISpecificationFactory, SpecificationFactory>();

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

        public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceConfig = GetServiceConfig(configuration);

            return services.RegisterConsulService(serviceConfig);
        }

        public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            return new ServiceConfig
            {
                ServiceDiscoveryAddress = configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
                ServiceAddress = configuration.GetValue<Uri>("ServiceConfig:serviceAddress"),
                ServiceName = configuration.GetValue<string>("ServiceConfig:serviceName"),
                ServiceId = configuration.GetValue<string>("ServiceConfig:serviceId")
            };
        }

        public static IServiceCollection RegisterConsulService(this IServiceCollection services, ServiceConfig serviceConfig)
        {
            if (serviceConfig == null)
                throw new ArgumentNullException(nameof(serviceConfig));

            var consulClient = CreateConsulClient(serviceConfig);

            services.AddSingleton(serviceConfig);
            services.AddSingleton<IHostedService, ServiceDiscoveryHostedService>();
            services.AddSingleton<IConsulClient, ConsulClient>(s => consulClient);

            return services;
        }

        private static ConsulClient CreateConsulClient(ServiceConfig serviceConfig)
        {
            return new ConsulClient(config =>
            {
                config.Address = serviceConfig.ServiceDiscoveryAddress;
            });
        }
    }
}
