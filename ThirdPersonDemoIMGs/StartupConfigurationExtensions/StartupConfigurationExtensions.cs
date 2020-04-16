using System;
using Microsoft.Extensions.DependencyInjection;
using ThirdPersonDemoIMGs.Services;
using ThirdPersonDemoIMGs.Services.Mappers;
using ThirdPersonDemoIMGsDomain.IRepositories;
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
    }
}
