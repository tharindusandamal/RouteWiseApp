using Microsoft.Extensions.DependencyInjection;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.APPLICATION.UseCases;
using RouteWiseApp.DOMAIN.AppModels;
using RouteWiseApp.INFRASTRUCTURE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RouteWiseApp.INFRASTRUCTURE.Services
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // Inject DI
            services.AddScoped<INodeRepository, NodeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INodePathFinder, NodePathFinderService>();

            return services;
        }
    }
}
