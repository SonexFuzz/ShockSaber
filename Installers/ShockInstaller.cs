using ShockSaber.API;
using ShockSaber.UI;
using ShockSaber.Trigger;
using Zenject;
namespace ShockSaber.Installers;

internal class ShockInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<PiShockAPI>().AsSingle();
        Container.BindInterfacesTo<Triggers>().AsSingle();

    }
}