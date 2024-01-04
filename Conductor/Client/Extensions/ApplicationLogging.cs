using Microsoft.Extensions.Logging;

namespace conductor.csharp.Client.Extensions
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory = new LoggerFactory();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);
    }
}
