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
        get => _config.ComboShock;
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
        get => _config.ComboVibrate;
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
    
    //Level Failed Shock
    [UIValue("enable_levelfailedshock")]
    private bool Enabled_LevelFailedShock
    {
        get => _config.LevelFailedShock;
        set
        {
            _config.LevelFailedShock = value;
        }
    }
    
    //Level Failed Shock Strength
    [UIValue("levelfailedshock_intensity_value")]
    private float LevelFailedShock_Intensity_value
    {
        get => _config.LevelFailedShockIntensity;
        set => _config.LevelFailedShockIntensity = (int)value;
    }
    
    //Level Failed Shock Duration 
    [UIValue("levelfailedshock_duration_value")]
    private float LevelFailedShock_Duration_value
    {
        get => _config.LevelFailedShockDuration;
        set => _config.LevelFailedShockDuration = (int)value;
    }
    
    //Level Failed Vibrate
    [UIValue("enable_levelfailedvibrate")]
    private bool Enabled_LevelFailedVibrate
    {
        get => _config.LevelFailedVibrate;
        set
        {
            _config.LevelFailedVibrate = value;
        }
    }
    
    //Level Failed Shock Strength
    [UIValue("levelfailedvibrate_intensity_value")]
    private float LevelFailedVibrate_Intensity_value
    {
        get => _config.LevelFailedVibrateIntensity;
        set => _config.LevelFailedVibrateIntensity = (int)value;
    }
    
    //Level Failed Shock Duration 
    [UIValue("levelfailedvibrate_duration_value")]
    private float LevelFailedVibrate_Duration_value
    {
        get => _config.LevelFailedVibrateDuration;
        set => _config.LevelFailedVibrateDuration = (int)value;
    }
    
    //Accuracy shock
    [UIValue("enable_accshock")]
    private bool Enabled_AccShock
    {
        get => _config.AccuracyShock;
        set
        {
            _config.AccuracyShock = value;
        }
    }
    
    //Required accuracy
    [UIValue("accuracy_value")]
    private float Accuracy_Intensity_value
    {
        get => _config.RequiredAccuracy;
        set => _config.RequiredAccuracy = (float)value;
    }
    
    //Accuracy shock Strength
    [UIValue("accshock_intensity_value")]
    private float AccShock_Intensity_value
    {
        get => _config.AccuracyShockIntensity;
        set => _config.AccuracyShockIntensity = (int)value;
    }
    
    //Accuracy shock Duration 
    [UIValue("accshock_duration_value")]
    private float AccShock_Duration_value
    {
        get => _config.AccuracyShockDuration;
        set => _config.AccuracyShockDuration = (int)value;
    }
    
    //Accuracy vibrate
    [UIValue("enable_accvibrate")]
    private bool Enabled_AccVibrate
    {
        get => _config.AccuracyVibrate;
        set
        {
            _config.AccuracyVibrate = value;
        }
    }
    
    //Accuracy shock Strength
    [UIValue("accvibrate_intensity_value")]
    private float AccVibrate_Intensity_value
    {
        get => _config.AccuracyVibrateIntensity;
        set => _config.AccuracyVibrateIntensity = (int)value;
    }
    
    //Accuracy shock Duration 
    [UIValue("accvibrate_duration_value")]
    private float AccVibrate_Duration_value
    {
        get => _config.AccuracyVibrateDuration;
        set => _config.AccuracyVibrateDuration = (int)value;
    }
    
    //Formatters
    [UIAction("intensity_slider_formatter")]
    private string Intensity_Slider_Formatter(float value) => $"{value.ToString("0")}%";
    
    [UIAction("duration_slider_formatter")]
    private string Duration_Slider_Formatter(float value_d) => $"{value_d.ToString("0")}s";
    
    [UIAction("accuracy_slider_formatter")]
    private string Accuracy_Slider_Formatter(float value) => $"{value.ToString("0.00")}%";
}