using Conductor.Client.Interfaces;
using Conductor.Client.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace Conductor.Client.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection WithConductorWorker<T>(this IServiceCollection services) where T : IWorkflowTask
        {
            services.AddTransient(typeof(IWorkflowTask), typeof(T));
            services.AddTransient(typeof(T));
            return services;
        }

        public static IServiceCollection WithOrkesApiClient(this IServiceCollection services, OrkesApiClient orkesApiClient)
        {
            services.AddHttpClient();
            services.AddOptions();
            services.AddSingleton(orkesApiClient);
            services.AddTransient<IConductorWorkerRestClient, ConductorWorkerRestClient>();
            services.AddSingleton<IWorkflowTaskCoordinator, WorkflowTaskCoordinator>();
            services.AddTransient<IWorkflowTaskExecutor, WorkflowTaskExecutor>();
            services.AddSingleton(orkesApiClient);
            return services;
        }

        public static IServiceCollection WithHostedService<T>(this IServiceCollection services) where T : BackgroundService
        {
            services.AddHostedService<T>();
            return services;
        }

        public static IServiceCollection WithConfiguration(this IServiceCollection services, Configuration configuration)
        {
            if (configuration == null)
            {
                services.AddSingleton<Configuration>();
            }
            else
            {
                services.AddSingleton(configuration);
            }
            return services;
        }

        public static IServiceCollection AddConductorClient(this IServiceCollection services, Action<IServiceProvider, HttpClient> configure)
        {
            if (configure != null)
            {
                services.AddHttpClient<IConductorWorkerRestClient, ConductorWorkerRestClient>(configure);
            }
            else
            {
                services.AddHttpClient<IConductorWorkerRestClient, ConductorWorkerRestClient>();
            }
            return services;
        }
    }
}
