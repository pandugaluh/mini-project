using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Persistance.Data;
using Project.Service.Course.Persistance.Repositories;

namespace Project.Service.Course.Persistance
{
    public static class LibraryExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IRepositoryCourse, RepositoryCourse>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
        }
    }
}
