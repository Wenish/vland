using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Colyseus;
using GameClient.Models;
using NativeWebSocket;
using UnityEngine;

namespace GameClient
{
    public sealed class Network
    {
        public ColyseusClient ColyseusClient;
        public ColyseusRoom<MatchState> GameRoom;

        private Network()
        {
            Debug.Log("Network created");
            ColyseusClient = new ColyseusClient("ws://" + GameSettings.Instance.ServerIp + ":" + GameSettings.Instance.ServerPort);
        }
        private static readonly Lazy<Network> lazy = new Lazy<Network>(() => new Network());
        public static Network Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public async Task<bool> ConnectToServer()
        {
            try
            {
                GameRoom = await ColyseusClient.JoinOrCreate<MatchState>("match");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async void CloseConnectionToServer()
        {
            if (GameRoom != null)
            {
                await GameRoom.Leave();
            }
        }
    }
}