using Zenject;

namespace ShockSaber.Installers;

internal class AppInstaller : Installer
{
    private readonly PluginConfig pluginConfig;

    public AppInstaller(PluginConfig pluginConfig)
    {
        this.pluginConfig = pluginConfig;
    }
        
    public override void InstallBindings()
    {
        Container.BindInstance(pluginConfig).AsSingle();
        Container.BindInterfacesAndSelfTo<PiShockLogin>().AsSingle().NonLazy();
    }
}