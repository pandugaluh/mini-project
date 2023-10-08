using Microsoft.Extensions.DependencyInjection;
using Project.Service.Course.Infrastructure.Kafka.Consumer;

namespace Project.Service.Course.Infrastructure
{
    public static class LibraryExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddHostedService<KafkaConsumerWorker>();
        }
    }
}
