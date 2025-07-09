using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ShockSaber.config;

public class PluginConfig
{
public virtual string username { get; set; } = "";
public virtual string apiKey { get; set; } = "";
public virtual string Code { get; set; } = "";
public virtual string senderName { get; set; } = "";
public virtual string Duration { get; set; } = "";
public virtual string Intensity { get; set; } = "";

}