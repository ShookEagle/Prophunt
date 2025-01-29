using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.DependencyInjection;
using Prophunt.Messaging;
using Prophunt.Public.Extensions;

namespace Prophunt;

public class ProphuntServiceCollection : IPluginServiceCollection<Prophunt>
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddProphuntMessaging();
    }
}