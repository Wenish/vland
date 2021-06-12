using System;
using GameClient.Models;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public sealed class StateHandlerCaptureFlag : IStateHandler<CaptureFlagState>
    {
        private static readonly Lazy<StateHandlerCaptureFlag> lazy = new Lazy<StateHandlerCaptureFlag>(() => new StateHandlerCaptureFlag());
        public static StateHandlerCaptureFlag Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void OnAdd(string key, CaptureFlagState stateType)
        {
            Debug.Log(key);
            GameObject gameObjectCaptureFlag = GameObject.Instantiate(GameSettings.Instance.CaptureFlag);
            MapManager.Instance.CaptureFlags.Add(key, gameObjectCaptureFlag);
            Debug.Log("CaptureFlagAdd");
        }

        public void OnChange(string key, CaptureFlagState stateType)
        {
            Debug.Log("On Change");
        }

        public void OnRemove(string key, CaptureFlagState stateType)
        {
            Debug.Log("On Remove");
        }
    }
}
