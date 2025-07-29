using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Extensions;

public class ServerExtensions
{
    public static void GetGameRules(out CCSGameRules? rules, out CCSGameRulesProxy? proxy)
    {
        var fecthedRulesProxy = Utilities.FindAllEntitiesByDesignerName<CCSGameRulesProxy>("cs_gamerules").FirstOrDefault();
        if (fecthedRulesProxy != null) { 
            proxy = fecthedRulesProxy;
            rules = fecthedRulesProxy.GameRules;
            return; }
        proxy = null;
        rules = null;
    }
}