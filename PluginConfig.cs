using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ShockSaber.config;

public class PluginConfig
{
    public virtual bool Enable { get; set; } = false;
    public virtual string Delay { get; set; } = "45";
    public virtual string username { get; set; } = "";
    public virtual string apiKey { get; set; } = "";
    public virtual string Code { get; set; } = "";
    public virtual string senderName { get; set; } = "";
    public virtual bool ComboShock { get; set; } = false;
    public virtual string ComboShockDuration { get; set; } = "2";
    public virtual string ComboShockIntensity { get; set; } = "50";
}