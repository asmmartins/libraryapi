using AutoMapper;
using Library.Api.Configuration.Extensions;
using Library.Infra.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Library.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) =>
            _config = config;

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.AddMyCors();
            services.AddMyRequestLocalizationOptions();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddMyControllers();
            services.AddMySwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddDependecyInjection(_config);
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMyExceptionHandler(env);
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMySwagger(_config);
            app.UseRequestLocalization();
            app.UseMyEndpoints();
        }
    }
}