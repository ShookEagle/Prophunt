using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Mod.Messaging;

public interface IMessenger
{
    void ToChat(CCSPlayerController controller, string key, params object[] args);
    void ToConsole(CCSPlayerController controller, string key, params object[] args);
    void ToCenter(CCSPlayerController controller, string key, params object[] args);
}