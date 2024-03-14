
using Domain.Students.Repositories;
using Infrastructure.Students.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Infrastructure.Extensions
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
