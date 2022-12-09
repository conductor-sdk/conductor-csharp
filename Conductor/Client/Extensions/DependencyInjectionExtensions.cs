using Microsoft.Extensions.Hosting;
using Conductor.Client.Interfaces;
using Conductor.Client.Worker;
using Microsoft.Extensions.DependencyInjection;
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

        public static IServiceCollection AddConductorWorker(this IServiceCollection services, Configuration configuration = null, Action<IServiceProvider, HttpClient> configureHttpClient = null)
        {
            services.AddHttpClient();
            services.AddOptions();
            services.AddSingleton(new OrkesApiClient(configuration));
            services.AddTransient<IConductorWorkerRestClient, ConductorWorkerRestClient>();
            services.AddSingleton(configuration != null ? configuration : new Configuration());
            services.AddSingleton<IWorkflowTaskCoordinator, WorkflowTaskCoordinator>();
            services.AddTransient<IWorkflowTaskExecutor, WorkflowTaskExecutor>();
            return services.AddConductorClient(configureHttpClient);
        }

        public static IServiceCollection AddWorkflowsWorkerService(this IServiceCollection services, BackgroundService backgroundService)
        {
            services.AddSingleton(backgroundService);
            return services;
        }

        public static IServiceCollection AddWorkflowTaskExecutor<T>(this IServiceCollection services) where T : IWorkflowTask
        {
            services.AddTransient(typeof(IWorkflowTask), typeof(T));
            services.AddTransient(typeof(T));
            return services;
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
    }
}
