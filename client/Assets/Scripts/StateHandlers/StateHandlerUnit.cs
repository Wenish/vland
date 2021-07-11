using System;
using System.Collections.Generic;
using GameClient.Controllers;
using GameClient.Managers;
using GameClient.Models;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public sealed class StateHandlerUnit : IStateHandler<UnitState>
    {
        private Dictionary<string, GameObject> Units = new Dictionary<string, GameObject>();
        private static readonly Lazy<StateHandlerUnit> lazy = new Lazy<StateHandlerUnit>(() => new StateHandlerUnit());
        public static StateHandlerUnit Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void OnAdd(string key, UnitState value)
        {
            Debug.Log(value);
            Debug.Log(value.id);
            GameObject gameObject = GameObject.Instantiate(
                ManagerSettings.Instance.Unit,
                new Vector3(value.position.x, value.position.y, value.position.z),
                new Quaternion()
            );
            gameObject.name = "Unit " + key;
            ControllerUnit controller = gameObject.GetComponent<ControllerUnit>();
            controller.Key = key;
            controller.UnitState = value;
            Units.Add(key, gameObject);
        }

        public void OnChange(string key, UnitState value)
        {

        }

        public void OnRemove(string key, UnitState value)
        {
            GameObject gameObject = Units[key];
            GameObject.Destroy(gameObject);
            Units.Remove(key);
        }
    }
}
