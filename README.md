# Prophunt

[![Discord](https://img.shields.io/discord/161245089774043136?style=for-the-badge&logo=discord&logoColor=%23ffffff&label=Discord&color=%235865F2
)](https://edgm.rs/discord)

The classic Prophunt gamemode, ported to Counter-Strike 2, with Source 2 Hammer Implementation.

## Downloads

## Versioning

Release tags  follow the [Semantic Versioning 2.0.0](https://semver.org/) standard,
where `MAJOR.MINOR.PATCH` are incremented based on the following:

- `MAJOR` when we make incompatible API changes,
- `MINOR` when we add functionality in a backwards-compatible manner.
- `PATCH` when we make backwards-compatible bug fixes.

## Status

- **⚙️ Server**
  - [ ] Stats/Analytics Sinks
  - [ ] Error reporting
  - [ ] Logging
  - [ ] Zones
- **Seeker**
  - [ ] 
- **Props**
  - [ ] 
- **🛕 Maps**
  - [ ] 

## Configuration

Configuration is done through CS#'s [FakeConVars](https://docs.cssharp.dev/examples/WithFakeConvars.html?q=fakeconvar).

You can search for the list of configurable
convars [like so]().

## Modding

Want to fork Prophunt and add in your own custom behavior? No sweat!
The prophunt repository is designed to act as a submodule.

```shell
git submodule add 
```

Once you have a dependency to `Prophunt.Public`, you can add in whatever functionality
you want from the current plugin, and choose to add in your own handlers if you wish.
Don't forget to register them with the service container!

To boot your plugin, simply iterate over all services that inherit from `IPluginBehavior`,
as demonstrated in `src/Prophunt/Prophunt.cs`:

```cs
foreach (IPluginBehavior extension in _extensions)
{
    //	Register all event handlers on the extension object
    RegisterAllAttributes(extension);

    //	Tell the extension to start it's magic
    extension.Start(this);
}
```

## Building

The prophunt plugin automatically builds to `build/Prophunt` when
using `dotnet publish src/Prophunt/Prophunt.csproj`.
Please use [SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or higher.

Note that only the `src/Prophunt` project is intended to be built directly.

## Using

Prophunt requires Counter Strike Sharp. If you don't have that installed, [follow the
install instructions here](https://docs.cssharp.dev/docs/guides/getting-started.html).

Install the plugin like any other Counter Strike Sharp plugin: drop the `Prophunt` folder into
`game/csgo/addons/counterstrikesharp/plugins`.
