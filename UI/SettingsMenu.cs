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
    
    [UIValue("intensity_value")]
    private float Intensity_value
    {
        get => float.TryParse(_config.Intensity, out var v) ? v : 50f;
        set => _config.Intensity = value.ToString("0");
    }
    
    [UIAction("set_intensity_value")]
    private void Set_Intensity_value(float value)
    {
        _config.Intensity = value.ToString("0");
    }
    
    [UIAction("intensity_slider_formatter")]
    private string Intensity_Slider_Formatter(float value) => $"{value.ToString("0")}%";


    [UIValue("duration_value")]
    private float Duration_value
    {
        get => float.TryParse(_config.Duration, out var v) ? v : 3f;
        set => _config.Duration = value.ToString("0");
    }
    
    [UIAction("set_duration_value")]
    private void Set_Duration_value(float value)
    {
        _config.Duration = value.ToString("0");
    }
    
    [UIAction("duration_slider_formatter")]
    private string Duration_Slider_Formatter(float value_d) => $"{value_d.ToString("0")}s";
}