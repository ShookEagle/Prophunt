using CounterStrikeSharp.API.Core.Capabilities;

namespace Prophunt.Public;

public static class API
{
    public static PluginCapability<IServiceProvider> Provider { get; } =
        new("prophunt:core");
}