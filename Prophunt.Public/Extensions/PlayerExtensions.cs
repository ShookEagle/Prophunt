using CounterStrikeSharp.API.Core;

namespace Prophunt.Public.Extensions;

public static class PlayerExtensions
{
    public static bool IsReal(this CCSPlayerController? player)
    {
        if (player == null) return false;
        if (!player.IsValid) return false;
        if (player.Connected != PlayerConnectedState.PlayerConnected) return false;
        if (player.IsHLTV) return false;
        return true;
    }
}