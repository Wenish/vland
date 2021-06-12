using System;
using System.Collections;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public void OnRemove()
        {
            throw new System.NotImplementedException();
        }
    }
}