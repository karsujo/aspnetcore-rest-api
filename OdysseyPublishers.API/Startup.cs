using Application;
using Application.Authors;
using Application.Books;
using Application.Common;
using AutoMapper;
using Infrastructure;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OdysseyPublishers.API
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
            services.AddInfrastructure(Configuration);
            services.AddApplication(Configuration);


            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AuthorDbProfile());
                opt.AddProfile(new BookDbProfile());
                opt.AddProfile(new AuthorDtoProfile());
                opt.AddProfile(new BookDtoProfile());


            });

            var mapper = config.CreateMapper();


            services.AddSingleton(mapper);

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters().ConfigureApiBehaviorOptions(setupAction =>
            {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    //Create problem details object
                    var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                    var problemDetials = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

                    //add additional info

                    problemDetials.Detail = "See the errors field for additional information.";
                    problemDetials.Instance = context.HttpContext.Request.Path;
                    // Find out which status code to return

                    var actionExecutingContext = (ActionExecutingContext)context;

                    //If model state is in error, and all params were found, they are validation errors

                    if ((context.ModelState.ErrorCount > 0) && (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                    {
                        problemDetials.Type = "https://OdysseyPub.com/modelvalidationproblem";
                        problemDetials.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetials.Title = "One or more validation errors occoured";

                        return new UnprocessableEntityObjectResult(problemDetials)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    }



                    //If arguments werent found / couldnt be parsed
                    problemDetials.Status = StatusCodes.Status400BadRequest;
                    problemDetials.Title = "One or more validation errors occoured";
                   

                    return new BadRequestObjectResult(problemDetials)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                
                  
                };

              
            });
            services.Configure<PersistenceConfigurations>(Configuration.GetSection("PersistenceSettings"));
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
                app.UseExceptionHandler(appBuilder =>
                {

                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error occoured. Please try again later"); //Add logging here if required
                    });

                });
            }

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
