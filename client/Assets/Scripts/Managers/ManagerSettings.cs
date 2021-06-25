using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameClient.Managers
{
    public class ManagerSettings : MonoBehaviour
    {
        public string Protocol = null;
        public string ServerIp = null;
        public string ServerPort = null;
        public string Token = null;
        public string Map = null;
        public GameObject MapFloor;
        public GameObject CapturePoint;
        public GameObject CaptureFlag;
        public GameObject Unit;

        public TileBase BlockGrass;
        public TileBase BlockSnow;
        public TileBase BlockDirt;
        public TileBase BlockBridge;

        private static ManagerSettings _instance;

        public static ManagerSettings Instance
        {
            get { return _instance; }
        }
        private void Awake()
        {
            Debug.Log("GameSettings Start");
            var serverip = GetArg("-serverip");
            ServerIp = serverip != null ? serverip : ServerIp;
            Debug.Log(ServerIp);

            var serverport = GetArg("-serverport");
            ServerPort = serverport != null ? serverport : ServerPort;
            Debug.Log(ServerPort);

            var token = GetArg("-token");
            Token = token != null ? token : Token;
            Debug.Log(Token);

            var map = GetArg("-map");
            Map = map != null ? map : Map;
            Debug.Log(Map);

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