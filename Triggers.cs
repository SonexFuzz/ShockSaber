using Zenject;
using System;

namespace ShockSaber
{
    public class Triggers : IInitializable, IDisposable
    {
        private readonly PiShockLogin _piShockLogin;
        private readonly PluginConfig _config;
        private DateTime _lastTriggerTime = DateTime.MinValue;

        public Triggers(PiShockLogin piShockLogin, PluginConfig config)
        {
            _piShockLogin = piShockLogin;
            _config = config;
        }

        public void Initialize()
        {
            BS_Utils.Utilities.BSEvents.comboDidBreak += OnComboDidBreak;
        }

        public void Dispose()
        {
            BS_Utils.Utilities.BSEvents.comboDidBreak -= OnComboDidBreak;
        }

        private void OnComboDidBreak()
        {
            if (!_config.Enable || _piShockLogin.Controller == null)
                return;

            int shock_intensity = _config.ComboShockIntensity;
            int shock_duration = _config.ComboShockDuration;
            int vibrate_intensity = _config.ComboVibrateIntensity;
            int vibrate_duration = _config.ComboVibrateDuration;
            int delaySeconds = _config.Delay;

            DateTime now = DateTime.Now;

            if ((now - _lastTriggerTime).TotalSeconds >= delaySeconds)
            {
                _lastTriggerTime = now;

                // Shock
                if (_config.ComboShock)
                {
                    _piShockLogin.Controller.OperatePiShock(shock_intensity, shock_duration, PiShockLibrary.Enums.PiShockOperations.Shock
                    );
                    Plugin.Log.Debug($"Combo Break: Shock({shock_intensity}%, {shock_duration}s)");
                }

                // Vibrate
                if (_config.ComboVibrate)
                {
                    _piShockLogin.Controller.OperatePiShock(vibrate_intensity, vibrate_duration, PiShockLibrary.Enums.PiShockOperations.Vibrate
                    );
                    Plugin.Log.Debug($"Combo Break: Vibrate({vibrate_intensity}%, {vibrate_duration}s)");
                }
            }
            else
            {
                double remaining = delaySeconds - (now - _lastTriggerTime).TotalSeconds;
                Plugin.Log.Debug($"Combo Break ignored: {remaining:0.00}s remaining in delay");
            }
        }
    }
}