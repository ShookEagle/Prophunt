using CounterStrikeSharp.API.Core;
using Microsoft.Extensions.Localization;
using Prophunt.Public.Behaviors;
using Prophunt.Public.Mod.Messaging;

namespace Prophunt.Messaging;

public class PrivateMessenger(BasePlugin basePlugin) : IPluginBehavior, IPrivateMessenger
{
    private readonly IStringLocalizer? _localizer = basePlugin.Localizer;
    
    
}