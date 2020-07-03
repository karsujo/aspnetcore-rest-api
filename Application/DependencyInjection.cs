using Application.Books;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdysseyPublishers.Application.Authors;
using OdysseyPublishers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            return services;
        }
    }
}
