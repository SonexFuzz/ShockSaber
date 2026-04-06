using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ShockSaber;

public class PluginConfig
{
    public virtual bool Enable { get; set; } = false;
    public virtual int Delay { get; set; } = 45;
    public virtual string username { get; set; } = "your_username_here";
    public virtual string apiKey { get; set; } = "your_api_key_here";
    public virtual string Code { get; set; } = "your_code_here";
    public virtual bool ComboShock { get; set; } = false;
    public virtual int ComboShockDuration { get; set; } = 2;
    public virtual int ComboShockIntensity { get; set; } = 50;
    public virtual bool ComboVibrate { get; set; } = false;
    public virtual int ComboVibrateDuration { get; set; } = 2;
    public virtual int ComboVibrateIntensity { get; set; } = 50;
    public virtual bool LevelFailedShock { get; set; } = false;
    public virtual int LevelFailedShockDuration { get; set; } = 2;
    public virtual int LevelFailedShockIntensity { get; set; } = 50;
    public virtual bool LevelFailedVibrate { get; set; } = false;
    public virtual int LevelFailedVibrateDuration { get; set; } = 2;
    public virtual int LevelFailedVibrateIntensity { get; set; } = 50;
    public virtual bool AccuracyShock { get; set; } = false;
    public virtual float RequiredAccuracy  { get; set; } = 90;
    public virtual int AccuracyShockDuration { get; set; } = 2;
    public virtual int AccuracyShockIntensity { get; set; } = 50;
    public virtual bool AccuracyVibrate { get; set; } = false;
    public virtual int AccuracyVibrateDuration { get; set; } = 2;
    public virtual int AccuracyVibrateIntensity { get; set; } = 50;
}