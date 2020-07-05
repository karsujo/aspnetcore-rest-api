using Application.Books;
using AutoMapper;
using Infrastructure.Authors;
using Infrastructure.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Infrastructure.Authors;
using OdysseyPublishers.Infrastructure.Common;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository, SqlRepositoryBase>(); //Or Singleton / Or Transient -- EF uses Scodped?
                                                                  //AutoMapper?
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AuthorDbProfile());
                opt.AddProfile(new BookDbProfile());

            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
