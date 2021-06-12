using UnityEngine;
using GameClient.Models;

namespace GameClient.Controllers
{
    public class ControllerCaptureFlag : MonoBehaviour
    {
        public string Key = null;
        private CaptureFlagState _captureFlagSate;
        public CaptureFlagState CaptureFlagState
        {
            get { return _captureFlagSate; }
            set
            {
                if (value?.position != null) {
                    transform.position = new Vector3(value.position.x, value.position.y, value.position.z);
                }
                _captureFlagSate = value;
            }
        }

        public void Start()
        {

        }

        public void Update()
        {

        }
    }
}