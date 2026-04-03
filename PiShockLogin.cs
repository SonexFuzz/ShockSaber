//Code borrowed and modified from https://github.com/MxPuffin/REPOShock/blob/master/src/REPOShock.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using PiShockClassLibrary.Models;
using PiShockClassLibrary.Services;
using Zenject;

namespace ShockSaber;

public class PiShockLogin : IInitializable
{
    private readonly PluginConfig _config;
    private readonly PiShockAPI _api;

    public PiShockController? Controller { get; private set; }

    public PiShockLogin(PluginConfig config)
    {
        _config = config;
        _api = new PiShockAPI(new HttpClient());
    }
    
    public async void Initialize()
    {
        try
        {
            if (string.IsNullOrEmpty(_config.username) || string.IsNullOrEmpty(_config.apiKey))
                throw new ArgumentException("Username or APIKey missing!");

            if (string.IsNullOrEmpty(_config.Code))
                throw new ArgumentException("ShareCode missing!");

            var sharecodes = _config.Code.Split(',');

            var devices = new List<PiShockDeviceInfo>();

            for (int i = 0; i < sharecodes.Length; i++)
            {
                devices.Add(new PiShockDeviceInfo($"Shocker {i}", sharecodes[i].Trim()));
            }

            Plugin.Log.Info("Logging into PiShock...");

            var userInfo = await _api.GetUserInfoFromAPI(_config.username, _config.apiKey);

            userInfo = userInfo.WithDevices(devices);

            Controller = new PiShockController(_api, userInfo);

            Plugin.Log.Info("PiShock login successful.");
        }
        catch (Exception ex)
        {
            Plugin.Log.Error($"PiShock login failed: {ex}");
        }
    }
}