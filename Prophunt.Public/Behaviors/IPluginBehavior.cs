using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Behaviors;

public interface IPluginBehavior : IDisposable
{
    void IDisposable.Dispose() { }
    void Start(BasePlugin basePlugin) { }
    void Start(BasePlugin basePlugin, bool hotreload) { Start(basePlugin); }
}