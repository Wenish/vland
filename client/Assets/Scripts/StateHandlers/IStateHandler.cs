using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public interface IStateHandler<StateType>
    {
        void OnAdd(string key, StateType stateType);
        void OnChange(string key, StateType stateType);
        void OnRemove(string key, StateType stateType);
    }
}
