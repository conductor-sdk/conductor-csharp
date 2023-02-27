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
            services.AddSingleton(configuration);
            services.AddSingleton<OrkesApiClient>(new OrkesApiClient(configuration));
            services.AddSingleton<IConductorWorkerClient, ConductorWorkerRestClient>();
            services.AddTransient<IWorkflowTaskCoordinator, WorkflowTaskCoordinator>();
            return services;
        }

        public static IServiceCollection WithHostedService<T>(this IServiceCollection services) where T : BackgroundService
        {
            services.AddHostedService<T>();
            return services;
        }
    }
}
