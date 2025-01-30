namespace Prophunt.Public.Mod.Messaging;

public interface IAnnouncer
{
    void Announce(string key, params object[] args);
    void AnnounceAnonymous(string key, string adminName, params object[] args);
}