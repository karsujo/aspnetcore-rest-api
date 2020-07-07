using Application;
using Application.Authors;
using Application.Common;
using AutoMapper;
using Infrastructure;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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


            });

            var mapper = config.CreateMapper();
     

            services.AddSingleton(mapper);

            services.AddControllers();
            services.Configure<PersistenceConfigurations>(Configuration.GetSection("PersistenceSettings"));
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
