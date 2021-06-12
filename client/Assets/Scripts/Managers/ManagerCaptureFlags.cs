using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.Managers
{
    public class ManagerCaptureFlags : MonoBehaviour
    {
        public Dictionary<string, GameObject> CaptureFlags = new Dictionary<string, GameObject>();
        private static ManagerCaptureFlags _instance;

        public static ManagerCaptureFlags Instance
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