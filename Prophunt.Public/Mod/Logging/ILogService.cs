using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Mod.Logging;

public interface ILogService
{
    void AppendLog(string key, params object[] args);
    void PrintLogs(CCSPlayerController? player);
}