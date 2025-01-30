using Microsoft.Extensions.DependencyInjection;
using Prophunt.Public.Extensions;
using Prophunt.Public.Mod.Logging;

namespace Prophunt.Logging;

public static class LoggingServiceExtension
{
    public static void AddProphuntLogging(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddPluginBehavior<ILogService, LogsManager>();
        
        serviceCollection.AddPluginBehavior<LogsCommand>();
    }
}