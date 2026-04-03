//Code borrowed and modified from https://github.com/MxPuffin/REPOShock/blob/master/src/PiShockController.cs
using PiShockClassLibrary.Services;
using PiShockClassLibrary.Models;
using PiShockLibrary.Models;
using PiShockLibrary.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ShockSaber
{
    public class PiShockController
    {
        private PiShockAPI _piShockAPI;
        private PiShockUserInfo _userInfo;
        
        public PiShockController(PiShockAPI piShockAPI, PiShockUserInfo piShockUserInfo)
        {
            _piShockAPI = piShockAPI;
            _userInfo = piShockUserInfo;
        }

        public void OperatePiShock(int intensity, int duration, PiShockOperations op)
        {
            Task.Run(async () =>
            {
                var tasks = new List<Task<bool>>();

                foreach (var device in _userInfo.Devices)
                {
                    var body = new PiShockOperateRequestBody(_userInfo, op, device.ShareCode, intensity, duration, "ShockSaber");
                    tasks.Add(_piShockAPI.SendOperationRequest(body));
                }

                var results = await Task.WhenAll(tasks);
                if (results.Any(success => !success))
                {
                    Plugin.Log.Warn("One or more PiShock requests failed to execute!");
                }
            });
        }
        
    }
}