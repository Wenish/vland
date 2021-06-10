// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.24
// 

using Colyseus.Schema;

namespace Game.Scripts.Models {
	public partial class CaptureFlagState : Schema {
		[Type(0, "string")]
		public string id = default(string);

		[Type(1, "ref", typeof(PositionState))]
		public PositionState position = new PositionState();

		[Type(2, "string")]
		public string teamId = default(string);
	}
}
