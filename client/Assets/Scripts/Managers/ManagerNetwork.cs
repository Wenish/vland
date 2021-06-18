using System.Collections;
using System.Collections.Generic;
using Colyseus;
using GameClient.Models;
using GameClient.StateHandlers;
using UnityEngine;

namespace GameClient.Managers
{
    public class ManagerNetwork : MonoBehaviour
    {
        public ColyseusClient ColyseusClient;
        public ColyseusRoom<MatchState> GameRoom;
        // Start is called before the first frame update

        private static ManagerNetwork _instance;

        public static ManagerNetwork Instance
        {
            get { return _instance; }
        }
        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        async void Start()
        {
            Debug.Log("Manager Network Start");
            ColyseusClient = new ColyseusClient("ws://" + ManagerSettings.Instance.ServerIp + ":" + ManagerSettings.Instance.ServerPort);
            try
            {
                Debug.Log("Connected to server");
                var options = new Dictionary<string, object>();
                options.Add("token", ManagerSettings.Instance.Token);
                options.Add("map", ManagerSettings.Instance.Map);
                GameRoom = await ColyseusClient.JoinOrCreate<MatchState>("match", options);
                
                GameRoom.State.map.capturePoints.OnAdd += StateHandlerCapturePoint.Instance.OnAdd;
                GameRoom.State.map.capturePoints.OnChange += StateHandlerCapturePoint.Instance.OnChange;
                GameRoom.State.map.capturePoints.OnRemove += StateHandlerCapturePoint.Instance.OnRemove;
                
                GameRoom.State.map.captureFlags.OnAdd += StateHandlerCaptureFlag.Instance.OnAdd;
                GameRoom.State.map.captureFlags.OnChange += StateHandlerCaptureFlag.Instance.OnChange;
                GameRoom.State.map.captureFlags.OnRemove += StateHandlerCaptureFlag.Instance.OnRemove;

                GameRoom.State.map.floorBlocks.OnAdd += StateHandlerFloorBlocks.Instance.OnAdd;
                GameRoom.State.map.floorBlocks.OnChange += StateHandlerFloorBlocks.Instance.OnChange;
                GameRoom.State.map.floorBlocks.OnRemove += StateHandlerFloorBlocks.Instance.OnRemove;
            }
            catch
            {
                Debug.LogError("Cant Connect To Server");
            }
        }
        async void OnApplicationQuit()
        {
            Debug.Log("On Application close try to leave room");
            if (GameRoom != null)
            {
                await GameRoom.Leave();
            }
        }
    }
}
