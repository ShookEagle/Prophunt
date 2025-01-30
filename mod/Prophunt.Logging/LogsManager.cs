using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Localization;
using Prophunt.Public.Behaviors;
using Prophunt.Public.Extensions;
using Prophunt.Public.Mod.Logging;

namespace Prophunt.Logging;

public class LogsManager : IPluginBehavior, ILogService
{
    private readonly List<string> _logMessages = [];
    private readonly IStringLocalizer _localizer;
    private readonly string _tTeamName;
    private readonly string _ctTeamName; 

    public LogsManager(BasePlugin plugin)
    {
        _localizer = plugin.Localizer;
        _tTeamName = _localizer["team.prop.name"];
        _ctTeamName = _localizer["team.seeker.name"];
    }

    public void AppendLog(string key, params object[] args)
    {
        for (int i = 0; i < args.Length; i++)
        { if (args[i] is CCSPlayerController playerController)
            { args[i] = FormatPlayerName(playerController); } }
        _logMessages.Add(_localizer[key, args]);
    }

    private void Clear() { _logMessages.Clear(); }
    
    public void PrintLogs(CCSPlayerController? player) {
        if (player == null || !player.IsReal()) {
            Server.PrintToConsole(_localizer["logs.begin_logs"]);
            foreach (var log in _logMessages) Server.PrintToConsole(log);
            Server.PrintToConsole(_localizer["logs.end_logs"]);
            return;
        }
        
        player.PrintToConsole(_localizer["logs.begin_logs"]);
        foreach (var log in _logMessages) player.PrintToConsole(log);
        player.PrintToConsole(_localizer["logs.end_logs"]);
    }

    private string FormatPlayerName(CCSPlayerController player)
    {
        var name = player.PlayerName;
        var prefix = player.Team == CsTeam.Terrorist ? $"({_tTeamName})" : $"({_ctTeamName})";
        return $"{prefix} {name}";
    }
    
    [GameEventHandler]
    public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info) {
        PrintLogs(null);
        foreach (var player in Utilities.GetPlayers())
        {
            PrintLogs(player);
        }
        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info) {
        Clear();
        return HookResult.Continue;
    }
}