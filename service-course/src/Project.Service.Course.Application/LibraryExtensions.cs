using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Service.Course.Application.Interfaces.Services;
using Project.Service.Course.Application.Options;
using Project.Service.Course.Application.Services;
using System.Reflection;

namespace Project.Service.Course.Application
{
    public static class LibraryExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IServiceCourse, ServiceCourse>();
            services.AddScoped<IServiceUser, ServiceUser>();
            services.AddScoped<IServiceKafka, ServiceKafka>();

            services.Configure<KafkaSettings>(configuration.GetSection("KafkaSettings"));
        }
    }
}
