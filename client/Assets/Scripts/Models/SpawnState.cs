// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.25
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class SpawnState : Schema {
		[Type(0, "ref", typeof(PositionState))]
		public PositionState position = new PositionState();
	}
}
