// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.24
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class TeamState : Schema {
		[Type(0, "string")]
		public string id = default(string);

		[Type(1, "string")]
		public string color = default(string);

		[Type(2, "number")]
		public float score = default(float);
	}
}
