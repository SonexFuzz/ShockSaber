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
}