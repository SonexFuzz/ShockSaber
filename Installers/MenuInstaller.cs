using Zenject;
using ShockSaber.UI;
namespace ShockSaber.Installers;
internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SettingsMenuManager>().AsSingle();

        Container.Bind<SettingsMenu>().AsSingle();
    }
}