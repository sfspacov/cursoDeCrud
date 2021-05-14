using Crud.Interfaces;
using Crud.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Core;

namespace Crud
{
    public class Startup : BaseEntity
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICity, City>();
            services.AddScoped<IUf, Uf>();
            services.AddScoped<IUsuario, Usuario>();
            services.AddHealthChecks()
            // Add a health check for a SQL Server database
            .AddSqlServer(connectionString, failureStatus: HealthStatus.Unhealthy, tags: new[] { "ready" });
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetEvaluationTimeInSeconds(5); //Configures the UI to poll for healthchecks updates every 5 seconds
            })
                .AddInMemoryStorage()
                .AddSqlServerStorage(connectionString);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Index}/{id?}");

                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    ResultStatusCodes = {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                        [HealthStatus.Unhealthy] =StatusCodes.Status503ServiceUnavailable
                    },
                    ResponseWriter = WriteHealthCheckReadyResponse,
                    Predicate = (check) => check.Tags.Contains("ready"),
                    AllowCachingResponses = false
                });

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {
                    Predicate = (check) => !check.Tags.Contains("ready"),
                    ResponseWriter = WriteHealthCheckLiveResponse,
                    AllowCachingResponses = false
                });

                endpoints.MapHealthChecks("/healthui", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI();
            });

            app.UseHealthChecksUI();
        }
        private Task WriteHealthCheckLiveResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                    new JProperty("OverallStatus", result.Status.ToString()),
                    new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00"))
                );

            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }

        private Task WriteHealthCheckReadyResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                    new JProperty("OverallStatus", result.Status.ToString()),
                    new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00")),
                    new JProperty("DependencyHealthChecks", new JObject(result.Entries.Select(dicItem =>
                        new JProperty(dicItem.Key, new JObject(
                                new JProperty("Status", dicItem.Value.Status.ToString()),
                                new JProperty("Duration", dicItem.Value.Duration.TotalSeconds.ToString("0:0.00")),
                                new JProperty("Exception", dicItem.Value.Exception?.Message),
                                new JProperty("Data", new JObject(dicItem.Value.Data.Select(dicData =>
                                    new JProperty(dicData.Key, dicData.Value))))
                            ))
                    )))
                );

            return httpContext.Response.WriteAsync(json.ToString(Formatting.Indented));
        }
    }
}
