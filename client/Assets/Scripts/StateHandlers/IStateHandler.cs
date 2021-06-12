using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient.StateHandlers
{
    public interface IStateHandler<Schema>
    {
        void OnAdd(string key, Schema value);
        void OnChange(string key, Schema value);
        void OnRemove(string key, Schema value);
    }
}
