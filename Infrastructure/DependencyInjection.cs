using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdysseyPublishers.Application.Common;
using OdysseyPublishers.Infrastructure.Common;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddTransient<IRepository, SqlRepositoryBase>();
            return services;
        }
    }
}
