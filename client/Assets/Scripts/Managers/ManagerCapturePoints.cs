using System.Collections;
using System.Collections.Generic;
using GameClient.Controllers;
using GameClient.Models;
using UnityEngine;

namespace GameClient.Managers
{
    public class ManagerCapturePoints : MonoBehaviour
    {
        public Dictionary<string, GameObject> CapturePoints = new Dictionary<string, GameObject>();
        private static ManagerCapturePoints _instance;

        public static ManagerCapturePoints Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}