using System;
using GameClient.Controllers;
using GameClient.Managers;
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
        public void OnAdd(string key, CaptureFlagState value)
        {
            GameObject gameObject = GameObject.Instantiate(ManagerSettings.Instance.CaptureFlag);
            gameObject.name = "Capture Flag " + key;
            ControllerCaptureFlag controller = gameObject.GetComponent<ControllerCaptureFlag>();
            controller.Key = key;
            controller.CaptureFlagState = value;
            ManagerCaptureFlags.Instance.CaptureFlags.Add(key, gameObject);
        }

        public void OnChange(string key, CaptureFlagState value)
        {
            GameObject gameObject = ManagerCaptureFlags.Instance.CaptureFlags[key];
            ControllerCaptureFlag controller = gameObject.GetComponent<ControllerCaptureFlag>();
            controller.CaptureFlagState = value;
        }

        public void OnRemove(string key, CaptureFlagState value)
        {
            GameObject gameObject = ManagerCaptureFlags.Instance.CaptureFlags[key];
            GameObject.Destroy(gameObject);
            ManagerCaptureFlags.Instance.CaptureFlags.Remove(key);
        }
    }
}
