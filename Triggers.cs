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
        private DateTime _lastTriggerTime = DateTime.MinValue;

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
            if (!_config.Enable || !_config.ComboShock)
                return;

            if (int.TryParse(_config.ComboShockIntensity, out int intensity) &&
                int.TryParse(_config.ComboShockDuration, out int duration) &&
                int.TryParse(_config.Delay, out int delaySeconds))
            {
                DateTime now = DateTime.Now;

                if ((now - _lastTriggerTime).TotalSeconds >= delaySeconds)
                {
                    _lastTriggerTime = now;
                    _ = _api.Shock(intensity, duration);
                    Plugin.Log.Debug($"Combo Break: Shock({intensity}, {duration})");
                }
                else
                {
                    double remaining = delaySeconds - (now - _lastTriggerTime).TotalSeconds;
                    Plugin.Log.Debug($"Combo Break ignored: {remaining:0.00}s remaining in delay");
                }
            }
            else
            {
                Plugin.Log.Warn("Invalid intensity/duration in config");
            }
        }

    }
}