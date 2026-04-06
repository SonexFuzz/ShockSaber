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
            BS_Utils.Utilities.BSEvents.levelFailed += LevelFailed;
            BS_Utils.Utilities.BSEvents.levelCleared += LevelCleared;
        }

        public void Dispose()
        {
            BS_Utils.Utilities.BSEvents.comboDidBreak -= OnComboDidBreak;
            BS_Utils.Utilities.BSEvents.levelFailed -= LevelFailed;
            BS_Utils.Utilities.BSEvents.levelCleared -= LevelCleared;
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
                    _piShockLogin.Controller.OperatePiShock(shock_intensity, shock_duration, PiShockLibrary.Enums.PiShockOperations.Shock);
                    Plugin.Log.Info($"Combo Break: Shock({shock_intensity}%, {shock_duration}s)");
                }

                // Vibrate
                if (_config.ComboVibrate)
                {
                    _piShockLogin.Controller.OperatePiShock(vibrate_intensity, vibrate_duration, PiShockLibrary.Enums.PiShockOperations.Vibrate);
                    Plugin.Log.Info($"Combo Break: Vibrate({vibrate_intensity}%, {vibrate_duration}s)");
                }
            }
            else
            {
                double remaining = delaySeconds - (now - _lastTriggerTime).TotalSeconds;
                Plugin.Log.Info($"Combo Break ignored: {remaining:0.00}s remaining in delay");
            }
        }

        private void LevelFailed(StandardLevelScenesTransitionSetupDataSO levelData, LevelCompletionResults results)
        {
            if (!_config.Enable || _piShockLogin.Controller == null)
                return;
            
            int shock_duration = _config.LevelFailedShockDuration;
            int shock_intensity = _config.LevelFailedShockIntensity;
            int vibrate_duration = _config.LevelFailedVibrateDuration;
            int vibrate_intensity = _config.LevelFailedVibrateIntensity;
            
            // Shock
            if (_config.LevelFailedShock)
            {
                _piShockLogin.Controller.OperatePiShock(shock_intensity, shock_duration, PiShockLibrary.Enums.PiShockOperations.Shock);
                Plugin.Log.Info($"Level Failed: Shock({shock_intensity}%, {shock_duration}s)");
            }

            // Vibrate
            if (_config.LevelFailedVibrate)
            {
                _piShockLogin.Controller.OperatePiShock(vibrate_intensity, vibrate_duration, PiShockLibrary.Enums.PiShockOperations.Vibrate);
                Plugin.Log.Info($"Level Failed: Vibrate({vibrate_intensity}%, {vibrate_duration}s)");
            }
        }

        private void LevelCleared(StandardLevelScenesTransitionSetupDataSO levelData, LevelCompletionResults results)
        {
            if (!_config.Enable || _piShockLogin.Controller == null)
                return;

            int shockDuration = _config.AccuracyShockDuration;
            int shockIntensity = _config.AccuracyShockIntensity;
            int vibrate_duration = _config.AccuracyVibrateDuration;
            int vibrate_intensity = _config.AccuracyVibrateIntensity;
            int score = results.modifiedScore;
            int maxScore = ScoreModel.ComputeMaxMultipliedScoreForBeatmap(BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.transformedBeatmapData);

            float accuracy = (float)score / maxScore * 100f;
            
            // Shock
            if (accuracy < _config.RequiredAccuracy && _config.AccuracyShock)
            {
                _piShockLogin.Controller.OperatePiShock(shockIntensity, shockDuration, PiShockLibrary.Enums.PiShockOperations.Shock);
                Plugin.Log.Info($"Didn't meet accuracy requirement: Shock({shockIntensity}%, {shockDuration}s)");
            }
            
            // Vibrate
            if (accuracy < _config.RequiredAccuracy && _config.AccuracyVibrate)
            {
                _piShockLogin.Controller.OperatePiShock(vibrate_intensity, vibrate_duration, PiShockLibrary.Enums.PiShockOperations.Shock);
                Plugin.Log.Info($"Didn't meet accuracy requirement: Shock({vibrate_intensity}%, {vibrate_duration}s)");
            }
        }
    }
}