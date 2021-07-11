using UnityEngine;
using GameClient.Models;

namespace GameClient.Controllers
{
    public class ControllerUnit : MonoBehaviour
    {
        public string Key = null;
        private UnitState _unitSate;
        public UnitState UnitState
        {
            get { return _unitSate; }
            set
            {
                _unitSate = value;
            }
        }

        public void Start()
        {
            Debug.Log("Unit Start");

        }

        public void Update()
        {

        }
    }
}