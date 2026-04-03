using BeatSaberMarkupLanguage.Attributes;

namespace ShockSaber.UI;

internal class SettingsMenu
{

    private readonly PluginConfig _config;

    public SettingsMenu(PluginConfig config)
    {
        _config = config;
    }
    
    //Delay slider
    [UIValue("delay_value")]
    private float Delay_value
    {
        get => _config.Delay;
        set => _config.Delay = (int)value;
    }
    
    //Enable switch
    [UIValue("enable")]
    private bool Enabled
    {
        get => _config.Enable;
        set
        {
            _config.Enable = value;
        }
    }
    
    //Combo Shock Toggle
    [UIValue("enable_comboshock")]
    private bool Enabled_ComboShock
    {
        get => _config.Enable;
        set
        {
            _config.ComboShock = value;
        }
    }
    
    //Combo Shock Strength
    [UIValue("comboshock_intensity_value")]
    private float ComboShock_Intensity_value
    {
        get => _config.ComboShockIntensity;
        set => _config.ComboShockIntensity = (int)value;
    }
    
    //Combo Shock Duration 
    [UIValue("comboshock_duration_value")]
    private float ComboShock_Duration_value
    {
        get => _config.ComboShockDuration;
        set => _config.ComboShockDuration = (int)value;
    }

    //Combo Vibrate Toggle
    [UIValue("enable_combovibrate")]
    private bool Enabled_ComboVibrate
    {
        get => _config.Enable;
        set
        {
            _config.ComboVibrate = value;
        }
    }
    
    //Combo Vibrate Strength
    [UIValue("combovibrate_intensity_value")]
    private float ComboVibrate_Intensity_value
    {
        get => _config.ComboVibrateIntensity;
        set => _config.ComboVibrateIntensity = (int)value;
    }

    //Combo Vibrate Duration 
    [UIValue("combovibrate_duration_value")]
    private float ComboVibrate_Duration_value
    {
        get => _config.ComboVibrateDuration;
        set => _config.ComboVibrateDuration = (int)value;
    }
    
    //Formatters
    [UIAction("intensity_slider_formatter")]
    private string Intensity_Slider_Formatter(float value) => $"{value.ToString("0")}%";
    
    [UIAction("duration_slider_formatter")]
    private string Duration_Slider_Formatter(float value_d) => $"{value_d.ToString("0")}s";
}