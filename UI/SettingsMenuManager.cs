using System;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace ShockSaber.UI;

internal class SettingsMenuManager : IInitializable, IDisposable
{
    private readonly SettingsMenu _settingsMenu;
    private readonly BSMLSettings bsmlSettings;

    private const string MenuName1 = "ShockSaber Config";
    private const string ResourcePath1 = nameof(ShockSaber) + ".UI.modUI.bsml";

    private const string MenuName2 = "ShockSaber Toggles";
    private const string ResourcePath2 = nameof(ShockSaber) + ".UI.modUI2.bsml";

    public SettingsMenuManager(SettingsMenu settingsMenu, BSMLSettings bsmlSettings)
    {
        this._settingsMenu = settingsMenu;
        this.bsmlSettings = bsmlSettings;
    }

    public void Initialize()
    {
        GameplaySetup.Instance.AddTab(MenuName1, ResourcePath1, _settingsMenu);
        GameplaySetup.Instance.AddTab(MenuName2, ResourcePath2, _settingsMenu);
    }

    public void Dispose()
    {
        bsmlSettings.RemoveSettingsMenu(_settingsMenu);
    }
}