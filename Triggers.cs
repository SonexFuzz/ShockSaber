using ShockSaber.API;
using ShockSaber.config;
using Zenject;
using System;

namespace ShockSaber.Trigger
{
    public class Triggers : IInitializable, IDisposable
    {

        private readonly PiShockAPI _api;
        private readonly PluginConfig _config;

        public Triggers(PiShockAPI api, PluginConfig config)
        {
            _api = api;
            _config = config;
        }

        public void Initialize()
        {
            BS_Utils.Utilities.BSEvents.comboDidBreak += BSEvents_comboDidBreak;
        }

        public void Dispose()
        {
            BS_Utils.Utilities.BSEvents.comboDidBreak -= BSEvents_comboDidBreak;
        }

        void BSEvents_comboDidBreak()
        {
            if (int.TryParse(_config.Intensity, out int intensity) &&
                int.TryParse(_config.Duration, out int duration))
            {
                _ = _api.Shock(intensity, duration);
                Plugin.Log.Debug($"Combo Break: Shock({intensity}, {duration})");
            }
            else
            {
                Plugin.Log.Warn("Invalid intensity/duration in config");
            }
        }
    }
}