using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Service.User.Application.Common.Behaviors;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Options;
using System.Reflection;

namespace Project.Service.User.Application
{
    public static class LibraryExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            ExtentionHelper.Initialize(configuration);
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<KafkaSettings>(configuration.GetSection("KafkaSettings"));
        }
    }
}
