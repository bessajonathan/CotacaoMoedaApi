using CotacaoMoeda.Api.Filtros;
using CotacaoMoeda.Api.PreRequest;
using CotacaoMoeda.Aplicacao.Fila.Comandos;
using CotacaoMoeda.Aplicacao.Interfaces;
using CotacaoMoeda.Application.Services;
using CotacaoMoeda.Domain.Interfaces;
using CotacaoMoeda.Domain.Services;
using CotacaoMoeda.Infra.Repository;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.Storage.SQLite;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;


namespace CotacaoMoeda.Api
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

            services.AddControllers();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddOpenApiDocument(x =>
            {
                x.Title = "CotacaoMoeda";
                x.Description = "Teste Wipro";
            });

            services.AddCors();

            //Adicionando MediatR
            services.AddMediatR(typeof(AdicionarItensCommand).GetTypeInfo().Assembly);

            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ExceptionFilter));
                })
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<AdicionarItensCommandValidator>());


            services.AddHangfire(config =>
                config.UseSQLiteStorage(Configuration.GetConnectionString("HangfireDatabase")));


            services.AddSingleton<IFilaApplicationService, FilaApplicationService>();
            services.AddSingleton<IFilaService, FilaService>();
            services.AddSingleton<IFilaRepository, FilaRepository>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/logs.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option =>
            {
                option.AllowAnyOrigin();
                option.AllowAnyHeader();
                option.AllowAnyMethod();
            });
            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseReDoc(x =>
            {
                x.Path = "/redoc";
            });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                ServerName = string.Format("{0}.{1}", Environment.MachineName, Guid.NewGuid().ToString())
            });

            app.UseHangfireDashboard("/jobs");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            new Jobs(app.ApplicationServices.GetService<IMediator>()).StartBackgroudJobs();
        }
    }
}
