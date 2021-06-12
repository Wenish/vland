using System;
using GameClient.Models;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public sealed class StateHandlerCapturePoint : IStateHandler<CapturePointState>
    {
        private static readonly Lazy<StateHandlerCapturePoint> lazy = new Lazy<StateHandlerCapturePoint>(() => new StateHandlerCapturePoint());
        public static StateHandlerCapturePoint Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void OnAdd(string key, CapturePointState stateType)
        {
            Debug.Log(key);
            GameObject gameObjectCapturePoint = GameObject.Instantiate(GameSettings.Instance.CapturePoint);
            MapManager.Instance.CapturePoints.Add(key, gameObjectCapturePoint);
            Debug.Log("CapturePointAdd");
            Debug.Log("On Add");
        }

        public void OnChange(string key, CapturePointState stateType)
        {
            Debug.Log("On Change");
        }

        public void OnRemove(string key, CapturePointState stateType)
        {
            Debug.Log("On Remove");
        }
    }
}
