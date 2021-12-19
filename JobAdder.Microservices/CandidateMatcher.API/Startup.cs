using CandidateMatcher.Common.IServices;
using CandidateMatcher.Common.Resources;
using CandidateMatcher.Common.Services;
using CandidateMatcher.Services.IServices;
using CandidateMatcher.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateMatcher.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.configurationService = new ConfigurationService(Configuration);
        }

        public IConfiguration Configuration { get; }
        IConfigurationService configurationService;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Candidate Matcher Api", Version = "v1" });

            });

            services.AddCors(cx =>
            {
                cx.AddPolicy("corsConfig", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                    .WithOrigins(configurationService.GetApplicationConfiguration().AllowCorsURL.Split(','));
                });
            });

            services.AddTransient<ICandidateMatcherService, CandidateMatcherService>();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IExternalApiService, ExternalApiService>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();

            services.AddSingleton<HttpClientFactory>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Candidate Matcher API V1 Services");
            });

            app.UseCors("corsConfig");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
