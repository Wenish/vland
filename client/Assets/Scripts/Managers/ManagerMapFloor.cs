using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.Managers
{
    public class ManagerMapFloor : MonoBehaviour
    {
        public GameObject MapFloor;
        private static ManagerMapFloor _instance;

        public static ManagerMapFloor Instance
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
        void Start()
        {
            MapFloor = Instantiate(ManagerSettings.Instance.MapFloor);
        }
    }
}