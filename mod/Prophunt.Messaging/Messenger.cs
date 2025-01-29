using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Localization;
using Prophunt.Public.Behaviors;
using Prophunt.Public.Extensions;
using Prophunt.Public.Mod.Messaging;
using Prophunt.Public.Utils;

namespace Prophunt.Messaging;

public class Messenger(BasePlugin basePlugin) : IPluginBehavior, IMessenger
{
    private readonly IStringLocalizer _localizer = basePlugin.Localizer;

    public void ToPlayerChat(CCSPlayerController controller, string key, params object[] args)
    {
        if (!controller.IsReal()) return;
        controller.PrintToChat(StringUtils.LocalizeString(_localizer, key, args));
    }
    
    public void ToPlayerConsole(CCSPlayerController controller, string key, params object[] args)
    {
        if (!controller.IsReal()) return;
        controller.PrintToConsole(StringUtils.LocalizeString(_localizer, key, args));
    }
    
    public void ToPlayerCenter(CCSPlayerController controller, string key, params object[] args)
    {
        if (!controller.IsReal()) return;
        controller.PrintToCenter(StringUtils.LocalizeString(_localizer, key, args));
    }
}