using Application.Books;
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

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
