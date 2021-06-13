using System;
using System.Collections.Generic;
using GameClient.Controllers;
using GameClient.Managers;
using GameClient.Models;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameClient.StateHandlers
{
    public sealed class StateHandlerFloorBlocks : IStateHandler<FloorBlockState>
    {
        private static readonly Lazy<StateHandlerFloorBlocks> lazy = new Lazy<StateHandlerFloorBlocks>(() => new StateHandlerFloorBlocks());
        public static StateHandlerFloorBlocks Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public void OnAdd(string key, FloorBlockState value)
        {
            Tilemap tilemap = ManagerMapFloor.Instance.Tilemap;
            TileBase tileBase;

            switch (value.type)
            {
                case "BlockGrass":
                    tileBase = ManagerSettings.Instance.BlockGrass;
                    break;
                case "BlockDirt":
                    tileBase = ManagerSettings.Instance.BlockDirt;
                    break;
                case "BlockSnow":
                    tileBase = ManagerSettings.Instance.BlockSnow;
                    break;
                case "BlockBridge":
                    tileBase = ManagerSettings.Instance.BlockBridge;
                    break;
                default:
                    tileBase = ManagerSettings.Instance.BlockGrass;
                    break;
            }
            tilemap.SetTile(new Vector3Int(int.Parse(value.position.x.ToString()), int.Parse(value.position.z.ToString()), 0), tileBase);
        }

        public void OnChange(string key, FloorBlockState value)
        {
            Debug.LogError("Floor Blocks cant be changed at the moment");
        }

        public void OnRemove(string key, FloorBlockState value)
        {
        }
    }
}
