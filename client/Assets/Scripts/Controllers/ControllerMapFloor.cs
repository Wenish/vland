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
                Terrain terrain = gameObject.GetComponent<Terrain>();
                terrain.terrainData.size = new Vector3(value, terrain.terrainData.size.y, terrain.terrainData.size.z);
                _width = value;
            }
        }

        private float _length;
        public float Length
        {
            get { return _length; }
            set
            {
                Terrain terrain = gameObject.GetComponent<Terrain>();
                terrain.terrainData.size = new Vector3(terrain.terrainData.size.x, terrain.terrainData.size.y, value);
                _length = value;
            }
        }
    }
}