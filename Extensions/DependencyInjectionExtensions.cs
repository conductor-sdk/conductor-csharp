using Conductor.Client;
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

        public static IServiceCollection AddConductorWorker(this IServiceCollection services, Action<ConductorClientSettings> configureSettings = null, Action<IServiceProvider, HttpClient> configureHttpClient = null)
        {
            services.AddHttpClient();
            services.AddOptions();
            services.Configure(configureSettings ?? ((config) => new ConductorClientSettings()));
            services.AddSingleton<IWorkflowTaskCoordinator, WorkflowTaskCoordinator>();
            services.AddTransient<IConductorRestClient, ConductorRestClient>();
            services.AddTransient<IWorkflowTaskExecutor, WorkflowTaskExecutor>();

            return services.AddConductorClient(configureHttpClient);
        }

        public static IServiceCollection AddConductorClient(this IServiceCollection services, Func<IServiceProvider, string> serverUrl)
        {
            services.AddHttpClient<IConductorRestClient, ConductorRestClient>((provider, client) =>
            {
                client.BaseAddress = new Uri(serverUrl(provider));
            });

            return services;
        }

        public static IServiceCollection AddConductorClient(this IServiceCollection services, Action<IServiceProvider, HttpClient> configure)
        {
            if (configure != null)
            {
                services.AddHttpClient<IConductorRestClient, ConductorRestClient>(configure);
            }
            else
            {
                services.AddHttpClient<IConductorRestClient, ConductorRestClient>();
            }

            return services;
        }
    }
}
