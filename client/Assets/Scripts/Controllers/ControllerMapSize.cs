using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.Controllers
{
    public class ControllerMapSize : MonoBehaviour
    {
        private int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
            }
        }

        private int _length;
        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }
    }
}