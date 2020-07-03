using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdysseyPublishers.Application.Authors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthorsRepository, AuthorsRepository>();
            return services;
        }
    }
}
