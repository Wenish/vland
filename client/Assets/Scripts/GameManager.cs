using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;
using Game.Scripts.Models;
using System;

namespace Game.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public ColyseusClient ColyseusClient;
        public ColyseusRoom<MatchState> GameRoom;
        public ColyseusRoom<MatchState> GameRoom2;
        private static GameManager _instance;

        public static GameManager Instance
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

        // Start is called before the first frame update
        public async void Start()
        {
            Debug.Log("Game Manager Start");
            var serverip = GetArg("-serverip");
            serverip = serverip != null ? serverip : "localhost";
            Debug.Log(serverip);

            var serverport = GetArg("-serverport");
            serverport = serverport != null ? serverport : "3000";
            Debug.Log(serverport);

            var roomname = GetArg("-roomname");
            roomname = roomname != null ? roomname : "match";
            Debug.Log(roomname);

            var token = GetArg("-token");
            Debug.Log(token);

            ColyseusClient = new ColyseusClient("ws://" + serverip + ":" + serverport);

            GameRoom = await ColyseusClient.JoinOrCreate<MatchState>("match");
        }
        private async void OnApplicationQuit()
        {
            Debug.Log("OnApplicationQuit: Leave GameRoom");
            if(GameRoom != null) {
                await GameRoom.Leave();
            }
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