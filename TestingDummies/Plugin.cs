using Exiled.API.Extensions;

namespace TestingDummies;

public class Plugin : Plugin<Config>
{
    public static Plugin Instance;

    public const string Permission = "devdummies";

    public override string Name => PluginInfo.PLUGIN_NAME;
    public override string Prefix => PluginInfo.PLUGIN_GUID.ToSnakeCase();
    public override string Author => PluginInfo.PLUGIN_AUTHORS;
    public override PluginPriority Priority => PluginPriority.Medium;
    public override Version Version => new (PluginInfo.PLUGIN_VERSION);
    public override Version RequiredExiledVersion => new (7, 0, 0);

    public override void OnEnabled()
    {           
        Instance = this;
        base.OnEnabled();
        Log.Warn($"{Name.ToUpper()} DOES AND WILL VIOLATE NORTHWOOD VSR WHEN DUMMIES ARE SPAWNED. USE ON PRIVATE SERVERS ONLY AND AT YOUR OWN RISK.");
    }

    public override void OnDisabled()
    {
        Instance = null;
        base.OnDisabled();
    }                
}