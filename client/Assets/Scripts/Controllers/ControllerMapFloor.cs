using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.Controllers
{
    public class ControllerMapFloor : MonoBehaviour
    {
        private float _width;
        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
            }
        }

        private float _length;
        public float Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }
    }
}