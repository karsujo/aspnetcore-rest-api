using Application.Authors;
using Application.Books;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdysseyPublishers.Application.Authors;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AuthorDbProfile());
                opt.AddProfile(new BookDbProfile());
         
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<IBookRepository, BookRepository>();

           

            return services;
        }
    }
}
