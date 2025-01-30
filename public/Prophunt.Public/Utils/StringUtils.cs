using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Localization;

namespace Prophunt.Public.Utils;

public class StringUtils {
    private static readonly List<string> StringsToRemove = [];

    static StringUtils() {
        ChatColorUtils.AllColors.ToList()
            .ForEach(c => StringsToRemove.Add(c.ToString()));
        typeof(ChatColors).GetFields()
            .Select(f => f.Name)
            .ToList()
            .ForEach(c => StringsToRemove.Add($"{{{c}}}"));
    }

    internal static string ReplaceChatColors(string message) {
        if (message.Contains('{')) {
            var modifiedValue = message;
            foreach (var field in typeof(ChatColors).GetFields()) {
                var pattern = $"{{{field.Name}}}";
                if (message.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                    modifiedValue = modifiedValue.Replace(pattern,
                        field.GetValue(null)!.ToString(),
                        StringComparison.OrdinalIgnoreCase);
            }

            return modifiedValue;
        }

        return message;
    }

    internal static string RemoveStrings(string message,
        List<string> stringsToRemove) {
        var modifiedValue = message;
        foreach (var s in stringsToRemove)
            modifiedValue = modifiedValue.Replace(s, string.Empty,
                StringComparison.OrdinalIgnoreCase);

        return modifiedValue;
    }

    public static string StripChatColors(string message) {
        return RemoveStrings(message, StringsToRemove);
    }

    public static string LocalizeMessage(IStringLocalizer localizer, string key, params object[] args)
    {
        string message = localizer[key, args];
        message = message.Replace("%prefix%", localizer["prefix"]);
        message = message.Replace("%admin%", localizer["admin"]);
        message = message.Replace("%error%", localizer["error"]);
        return message;
    }
}