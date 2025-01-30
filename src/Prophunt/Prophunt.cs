using System.Collections.Immutable;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prophunt.Public;
using Prophunt.Public.Behaviors;

namespace Prophunt;

public class Prophunt : BasePlugin {
  public static Prophunt? Instance { get; private set; }
  private readonly IServiceProvider provider;
  private IReadOnlyList<IPluginBehavior>? extensions;
  private IServiceScope? scope;

  /// <summary>
  ///   The Prophunt plugin.
  /// </summary>
  /// <param name="provider"></param>
  public Prophunt(IServiceProvider provider)
  { Instance = this; this.provider = provider; }

  /// <inheritdoc />
  public override string ModuleName => "Prophunt";

  /// <inheritdoc />
  public override string ModuleVersion
    => $"v0.0.1";

  /// <inheritdoc />
  public override string ModuleAuthor => "ShookEagle";

  /// <inheritdoc />
  public override void Load(bool hotReload) {
    //  Load Managers
    Logger.LogInformation("[Prophunt] Loading...");

    scope = provider.CreateScope();
    extensions = scope.ServiceProvider.GetServices<IPluginBehavior>()
     .ToImmutableList();

    Logger.LogInformation("[Prophunt] Found {@BehaviorCount} behaviors.",
      extensions.Count);

    foreach (var extension in extensions) {
      //	Register all event handlers on the extension object
      RegisterAllAttributes(extension);

      //	Tell the extension to start it's magic
      extension.Start(this, hotReload);

      Logger.LogInformation("[Prophunt] Loaded behavior {@Behavior}",
        extension.GetType().FullName);
    }

    //	Expose the scope to other plugins
    Capabilities.RegisterPluginCapability(API.Provider, () => {
      if (scope == null)
        throw new InvalidOperationException(
          "Prophunt does not have a running scope! Is the Prophunt plugin loaded?");

      return scope.ServiceProvider;
    });

    base.Load(hotReload);
  }

  /// <inheritdoc />
  public override void Unload(bool hotReload) {
    Logger.LogInformation("[Prophunt] Shutting down...");

    if (extensions != null)
      foreach (var extension in extensions)
        extension.Dispose();

    //	Dispose of original extensions scope
    //	When loading again we will get a new scope to avoid leaking state.
    scope?.Dispose();
    scope = null;

    base.Unload(hotReload);
  }
}