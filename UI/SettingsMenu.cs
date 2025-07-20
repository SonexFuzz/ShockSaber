using BeatSaberMarkupLanguage.Attributes;
using ShockSaber.config;

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
        get => float.TryParse(_config.Delay, out var v) ? v : 3f;
        set => _config.Delay = value.ToString("0");
    }

    [UIAction("set_delay_value")]
    private void Set_Delay_value(float value)
    {
        _config.Delay = value.ToString("0");
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

    [UIAction("set_enabled")]
    private void SetEnabled(bool value)
    {
        Enabled = value;
    }
    
    //Combo Break
    [UIValue("intensity_value")]
    private float Intensity_value
    {
        get => float.TryParse(_config.ComboShockIntensity, out var v) ? v : 50f;
        set => _config.ComboShockIntensity = value.ToString("0");
    }

    [UIAction("set_intensity_value")]
    private void Set_Intensity_value(float value)
    {
        _config.ComboShockIntensity = value.ToString("0");
    }
    
    [UIValue("duration_value")]
    private float Duration_value
    {
        get => float.TryParse(_config.ComboShockDuration, out var v) ? v : 3f;
        set => _config.ComboShockDuration = value.ToString("0");
    }

    [UIAction("set_duration_value")]
    private void Set_Duration_value(float value)
    {
        _config.ComboShockDuration = value.ToString("0");
    }
    
    [UIValue("enable_cs")]
    private bool Enabled_CS
    {
        get => _config.Enable;
        set
        {
            _config.ComboShock = value;
        }
    }

    [UIAction("set_cs_enabled")]
    private void SetEnabled_CS(bool value)
    {
        Enabled_CS = value;
    }
    
    //Formatters
    [UIAction("intensity_slider_formatter")]
    private string Intensity_Slider_Formatter(float value) => $"{value.ToString("0")}%";
    
    [UIAction("duration_slider_formatter")]
    private string Duration_Slider_Formatter(float value_d) => $"{value_d.ToString("0")}s";
    
}