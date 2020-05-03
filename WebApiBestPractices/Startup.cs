using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebApiBestPractices.Extantions;
using WebApiBestPractices.ValidationAttributes;

namespace WebApiBestPractices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            }); 

            services.ConfigureMySqlContext(Configuration);
            services.ConfigureRepositories();

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ModelValidationAttribute>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionMiddleware(); // handle exceptions via middleware


            app.UseSerilogRequestLogging();



            /* //handel exception native way
             app.UseExceptionHandler(conf =>
                {
                    conf.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            var ex = error.Error;

                            await context.Response.WriteAsync(new ErrorDetails
                            {
                                StatusCode = 500,
                                ErrorMessage = ex.Message
                            }.ToString());
                        }
                    });
                });

                */
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
