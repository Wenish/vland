using UnityEngine;
using GameClient.Models;

namespace GameClient.Controllers
{
    public class ControllerCapturePoint : MonoBehaviour
    {
        public string Key = null;
        private CapturePointState _capturePointSate;
        public CapturePointState CapturePointState
        {
            get { return _capturePointSate; }
            set
            {
                if (value?.position != null)
                {
                    transform.position = new Vector3(value.position.x, value.position.y, value.position.z);
                }
                if (value?.radius != null)
                {
                    transform.localScale = new Vector3(value.radius, 1, value.radius);
                }
                _capturePointSate = value;
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