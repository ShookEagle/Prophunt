using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.DependencyInjection;
using Prophunt.Messaging;

namespace Prophunt;

public class ProphuntServiceCollection : IPluginServiceCollection<Prophunt>
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddProphuntMessaging();
    }
}