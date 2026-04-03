using Zenject;

namespace ShockSaber.Installers;

internal class ShockInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Triggers>().AsSingle();
    }
}