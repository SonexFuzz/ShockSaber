using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Zenject;
using ShockSaber.Installers;
using ShockSaber.config;
using IpaLogger = IPA.Logging.Logger;
using IpaConfig = IPA.Config.Config;


namespace ShockSaber;

[Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
public class Plugin
{
    internal static IpaLogger Log { get; private set; } = null!;

    [Init]
    public Plugin(IpaLogger ipaLogger, IpaConfig ipaConfig, Zenjector zenjector, PluginMetadata pluginMetadata)
    {
        Log = ipaLogger;
        zenjector.UseLogger(Log);


        var pluginConfig = ipaConfig.Generated<PluginConfig>();
        
        zenjector.Install<AppInstaller>(Location.App, pluginConfig);
        
        zenjector.Install<MenuInstaller>(Location.Menu);

        zenjector.Install<ShockInstaller>(Location.Singleplayer);
 
        Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
    }
}