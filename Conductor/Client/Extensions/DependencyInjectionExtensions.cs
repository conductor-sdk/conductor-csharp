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
        public static IServiceCollection AddConductorWorkflowTask<T>(this IServiceCollection services) where T : IWorkflowTask
        {
            services.AddTransient(typeof(IWorkflowTask), typeof(T));
            services.AddTransient(typeof(T));
            return services;
        }

        public static IServiceCollection AddConductorWorker(this IServiceCollection services, Configuration configuration = default(Configuration), Action<IServiceProvider, HttpClient> configureHttpClient = null)
        {
            services.AddHttpClient();
            services.AddOptions();
            services.AddSingleton<Configuration>(configuration);
            services.AddSingleton<OrkesApiClient>();
            services.AddSingleton<IConductorWorkerRestClient, ConductorWorkerRestClient>();
            services.AddTransient<IConductorWorkerRestClient, ConductorWorkerRestClient>();
            services.AddSingleton<IWorkflowTaskCoordinator, WorkflowTaskCoordinator>();
            services.AddTransient<IWorkflowTaskExecutor, WorkflowTaskExecutor>();
            return services.AddConductorClient(configureHttpClient);
        }

        public static IServiceCollection AddConductorClient(this IServiceCollection services, Func<IServiceProvider, string> serverUrl)
        {
            services.AddHttpClient<IConductorWorkerRestClient, ConductorWorkerRestClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(serverUrl(provider));
            });
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

        public static IServiceCollection WithHostedService<T>(this IServiceCollection services) where T : BackgroundService
        {
            services.AddHostedService<T>();
            return services;
        }

    }
}
