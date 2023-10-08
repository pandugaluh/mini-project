using Microsoft.Extensions.DependencyInjection;
using Project.Service.User.Infrastructure.Kafka.Producer;

namespace Project.Service.User.Infrastructure
{
    public static class LibraryExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IKafkaProducer, KafkaProducer>();
        }
    }
}
