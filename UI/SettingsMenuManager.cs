using System;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace ShockSaber.UI;

internal class SettingsMenuManager : IInitializable, IDisposable
{
    private readonly SettingsMenu _settingsMenu;
    private readonly BSMLSettings bsmlSettings;
        
    private const string MenuName = nameof(ShockSaber);
    private const string ResourcePath = nameof(ShockSaber) + ".UI.modUI.bsml";

    public SettingsMenuManager(SettingsMenu settingsMenu, BSMLSettings bsmlSettings)
    {
        this._settingsMenu = settingsMenu;
        this.bsmlSettings = bsmlSettings;
    }

    public void Initialize()
    {
        GameplaySetup.Instance.AddTab(MenuName, ResourcePath, _settingsMenu);
    }

    public void Dispose()
    {
        bsmlSettings.RemoveSettingsMenu(_settingsMenu);
    }
}