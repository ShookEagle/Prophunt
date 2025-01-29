using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Mod.Messaging;

public interface IMessenger
{
    void ToPlayerChat(CCSPlayerController controller, string key, params object[] args);
    void ToPlayerConsole(CCSPlayerController controller, string key, params object[] args);
    void ToPlayerCenter(CCSPlayerController controller, string key, params object[] args);
}