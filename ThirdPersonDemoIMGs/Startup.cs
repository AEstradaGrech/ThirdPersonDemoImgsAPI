using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Swagger;
using ThirdPersonDemoIMGs.StartupConfigurationExtensions;
using ThirdPersonDemoIMGsInfrasturcture.Context;
using ThirdPersonDemoIMGsInfrasturcture.Helpers;

namespace ThirdPersonDemoIMGs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                        options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
                    });

            //Docker stup
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            StaticStrings.ConnectionString = Configuration["DbConnectionString"];

            services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionString));

            

            services.RegisterServices();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "TPS IMGs", Version = "v1", });
                //config.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
       
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

            //app.UseCors("CorsPolicy");

            app.UseCors("CorsPolicy")
               .ConfigureGlobalExceptionHandler()
               .ManageMigrations()
               .UseHttpsRedirection()
               .UseMvc()
               .UseSwagger()
               .UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "TPS IMGs")); ;

            //app.UseHttpsRedirection();

            //app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "TPS IMGs"));

           // app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            
        }
    }
}
