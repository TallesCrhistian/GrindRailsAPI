using GrindRailsAPI.Data.Context;
using GrindRailsAPI.Data.Interfaces;
using GrindRailsAPI.Data.WorkUnit;
using Microsoft.EntityFrameworkCore;

namespace GrindRailsAPI.API
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration iConfiguration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseNpgsql(iConfiguration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, LogLevel.Information));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection WorkUnit(this IServiceCollection services)
        {
            services.AddScoped<IWorkUnit, WorkUnit>();
            return services;
        }
    }
}

