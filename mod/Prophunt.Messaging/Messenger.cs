using CounterStrikeSharp.API.Core;
using Prophunt.Public.Behaviors;
using Prophunt.Public.Utils;
using Prophunt.Public.Mod.Messaging;

namespace Prophunt.Messaging;

public class Messenger(BasePlugin plugin) : IPluginBehavior, IMessenger
{
    public void ToChat(CCSPlayerController controller, string key, params object[] args)
    {
        controller.PrintToChat(StringUtils.LocalizeMessage(plugin.Localizer, key, args));
    }

    public void ToConsole(CCSPlayerController controller, string key, params object[] args)
    {
        controller.PrintToConsole(StringUtils.LocalizeMessage(plugin.Localizer, key, args));
    }

    public void ToCenter(CCSPlayerController controller, string key, params object[] args)
    {
        controller.PrintToCenter(StringUtils.LocalizeMessage(plugin.Localizer, key, args));
    }
}