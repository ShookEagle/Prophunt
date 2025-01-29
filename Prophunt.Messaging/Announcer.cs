using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Admin;
using NUnit.Framework.Internal;
using Prophunt.Public.Behaviors;
using Prophunt.Public.Extensions;
using Prophunt.Public.Mod.Messaging;
using Prophunt.Public.Utils;

namespace Prophunt.Messaging;

public class Announcer(BasePlugin plugin) : IPluginBehavior, IAnnouncer
{
    public void Announce(string key, params object[] args)
    {
        var players = Utilities.GetPlayers().Where(p => p.IsReal());
        var message = StringUtils.LocalizeMessage(plugin.Localizer, key, args);
        foreach (var recipient in players)
        {
            recipient.PrintToChat(message);
        }
    }
    
    public void AnnounceAnonymous(string key, string adminName, params object[] args)
    {
        var players = Utilities.GetPlayers().Where(p => p.IsReal());
        
        var adminArgs = new object[] {adminName}.Concat(args).ToArray();
        var adminMessage = StringUtils.LocalizeMessage(plugin.Localizer, key, adminArgs);
        
        var regularArgs = new object[] {"ADMIN"}.Concat(args).ToArray();
        var regularMessage = StringUtils.LocalizeMessage(plugin.Localizer, key, regularArgs);
        
        foreach (var recipient in players)
        {
            if (!AdminManager.PlayerHasPermissions(recipient, "prophunt.admin"))
            {
                recipient.PrintToChat(regularMessage);
            }
            recipient.PrintToChat(adminMessage);
        }
    }
}