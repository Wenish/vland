using System;
using System.Collections;
using System.Collections.Generic;
using GameClient.Controllers;
using GameClient.Managers;
using GameClient.Models;
using GameClient.StateHandlers;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public sealed class StateHandlerMapFloor
    {
        private static readonly Lazy<StateHandlerMapFloor> lazy = new Lazy<StateHandlerMapFloor>(() => new StateHandlerMapFloor());
        public static StateHandlerMapFloor Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void OnChange(List<Colyseus.Schema.DataChange> changes)
        {
            GameObject gameObject = ManagerMapFloor.Instance.MapFloor;
            ControllerMapSize controller = gameObject.GetComponent<ControllerMapSize>();
            controller.Width = ManagerNetwork.Instance.GameRoom.State.map.mapSize.width;
            controller.Length = ManagerNetwork.Instance.GameRoom.State.map.mapSize.length;
        }

        public void OnRemove()
        {
            throw new System.NotImplementedException();
        }
    }
}