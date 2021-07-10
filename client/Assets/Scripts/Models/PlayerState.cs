// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.25
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class PlayerState : Schema {
		[Type(0, "string")]
		public string sessionId = default(string);

		[Type(1, "string")]
		public string username = default(string);

		[Type(2, "string")]
		public string unitId = default(string);
	}
}
