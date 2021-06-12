using System;
using System.Collections.Generic;
using GameClient.Controllers;
using GameClient.Managers;
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
        public void OnAdd(string key, CapturePointState value)
        {
            GameObject gameObject = GameObject.Instantiate(ManagerSettings.Instance.CapturePoint);
            gameObject.name = "Capture Point " + key;
            ControllerCapturePoint controller = gameObject.GetComponent<ControllerCapturePoint>();
            controller.Key = key;
            controller.capturePointState = value;
            ManagerCapturePoints.Instance.CapturePoints.Add(key, gameObject);
            Debug.Log("On Add CapturePointState");
        }

        public void OnChange(string key, CapturePointState value)
        {
            GameObject gameObject = ManagerCapturePoints.Instance.CapturePoints[key];
            ControllerCapturePoint controller = gameObject.GetComponent<ControllerCapturePoint>();
            controller.capturePointState = value;
            Debug.Log("On Change CapturePointState");
        }

        public void OnRemove(string key, CapturePointState value)
        {
            GameObject gameObject = ManagerCapturePoints.Instance.CapturePoints[key];
            GameObject.Destroy(gameObject);
            ManagerCapturePoints.Instance.CapturePoints.Remove(key);
            Debug.Log("On Remove CapturePointState");
        }
    }
}
