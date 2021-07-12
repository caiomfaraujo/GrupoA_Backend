using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository.Interface;
using Repository.Repository;
using Service.Interface;
using Service.Service;
using System;
using System.Data;
using System.Linq;
using static Domain.MySqlSettings;

namespace Api
{
    public class Startup
    {
        private readonly Microsoft.Extensions.Hosting.IHostingEnvironment _environment;
        public IConfigurationRoot Configuration { get; }

        private const string _defaultCorsPolicyName = "*";
        private string[] BuscaUrlHabilitadasNoCors()
        {
            var urlsParaCors = Configuration["App:CorsOrigins"]
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.RemovePostFix("/"))
                .ToArray();

            return urlsParaCors;
        }

        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            _environment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            SettingsDefault.Load(Configuration);
            HostingEnvironmentService.Load((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy(_defaultCorsPolicyName,
                    builder => builder.WithOrigins(BuscaUrlHabilitadasNoCors())
                        .AllowAnyHeader()
                        .AllowAnyMethod())
            );
            
            //ConnectionString - MySQL
            services.AddTransient<MySqlDB>(_ => new MySqlDB(Configuration["ConnectionStrings:ConnectionMySql"]));

            //Interfaces
            services.AddSingleton<IAlunoRepository, AlunoRepository>();
            services.AddSingleton<IAlunoService, AlunoService>();            

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Desafio Grupo A - Web API - " + _environment.EnvironmentName, 
                    Version = "1.0.0.0", 
                    Description = "Desafio Grupo A - Web API",                    
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Intelbras");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseCors(_defaultCorsPolicyName);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
