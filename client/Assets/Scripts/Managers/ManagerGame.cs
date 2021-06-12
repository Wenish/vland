using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colyseus;
using GameClient.Models;
using System;
using UnityEngine.SceneManagement;
using GameClient.StateHandlers;

namespace GameClient.Managers
{
    public class ManagerGame : MonoBehaviour
    {
        private static ManagerGame _instance;

        public static ManagerGame Instance
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
        public void Start()
        {
            Debug.Log("Game Manager Start");
            SceneManager.LoadScene("MapScene", LoadSceneMode.Additive);
        }
    }
}