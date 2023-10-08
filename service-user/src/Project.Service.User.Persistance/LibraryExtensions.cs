using Microsoft.Extensions.DependencyInjection;
using Project.Service.User.Application.Interfaces.Repositories;
using Project.Service.User.Persistance.Repositories.User;

namespace Project.Service.User.Persistance
{
    public static class LibraryExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryUser, RepositoryUser>();
        }
    }
}
