using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;
using GameClient.Models;
using System;
using UnityEngine.SceneManagement;

namespace GameClient
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get { return _instance; }
        }

        // Start is called before the first frame update
        public async void Start()
        {
            Debug.Log("Game Manager Start");

            SceneManager.LoadScene("MapScene", LoadSceneMode.Additive);

            await Network.Instance.ConnectToServer();

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
        private void OnApplicationQuit()
        {
            Debug.Log("OnApplicationQuit: Leave GameRoom");
            Network.Instance.CloseConnectionToServer();
        }
    }
}