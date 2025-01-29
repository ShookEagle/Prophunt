using Prophunt.Public.Behaviors;
using Prophunt.Public.Mod.Messaging;

namespace Prophunt.Messaging;

public class Announcer(IMessenger messenger) : IPluginBehavior, IAnnouncer
{
    
}