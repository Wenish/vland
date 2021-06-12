using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameClient.Models;

namespace GameClient
{

    public static class StateHandler
    {
        public static void OnCapturePointAdd(string key, CapturePointState capturePointState)
        {
            Debug.Log(key);
            GameObject gameObjectCapturePoint = Object.Instantiate(GameSettings.Instance.CapturePoint);
            MapManager.Instance.CapturePoints.Add(key, gameObjectCapturePoint);
            Debug.Log("CapturePointAdd");
        }
        public static void OnCaptureFlagAdd(string key, CaptureFlagState captureFlagState)
        {
            Debug.Log(key);
            GameObject gameObjectCaptureFlag = Object.Instantiate(GameSettings.Instance.CaptureFlag);
            MapManager.Instance.CaptureFlags.Add(key, gameObjectCaptureFlag);
            Debug.Log("CaptureFlagAdd");
        }
    }
}