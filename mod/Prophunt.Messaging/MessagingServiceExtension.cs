using Microsoft.Extensions.DependencyInjection;
using Prophunt.Public.Extensions;
using Prophunt.Public.Mod.Messaging;

namespace Prophunt.Messaging;

public static class MessagingServiceExtension
{
    public static void AddProphuntMessaging(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddPluginBehavior<IPrivateMessenger, PrivateMessenger>();
    }
}