using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
    public class GameSettings : MonoBehaviour
    {
        public string ServerIp = null;
        public string ServerPort = null;
        public string Token = null;
        public GameObject CapturePoint;
        public GameObject CaptureFlag;
        public GameObject Unit;
        private static GameSettings _instance;

        public static GameSettings Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            Debug.Log("GameSettings Start");
            var serverip = GetArg("-serverip");
            ServerIp = serverip != null ? serverip : "localhost";
            Debug.Log(ServerIp);

            var serverport = GetArg("-serverport");
            ServerPort = serverport != null ? serverport : "3000";
            Debug.Log(ServerPort);

            var Token = GetArg("-token");
            Debug.Log(Token);

            // Singleton Stuff
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        private static string GetArg(string name)
        {
            var args = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && args.Length > i + 1)
                {
                    return args[i + 1];
                }
            }
            return null;
        }

    }
}