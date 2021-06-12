using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameClient.Models;

namespace GameClient
{
    public class MapManager : MonoBehaviour
    {
        public Dictionary<string, GameObject> CapturePoints = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> CaptureFlags = new Dictionary<string, GameObject>();
        private static MapManager _instance;

        public static MapManager Instance
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
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}