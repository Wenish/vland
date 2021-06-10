// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.24
// 

using Colyseus.Schema;

namespace Game.Scripts.Models {
	public partial class PlayerState : Schema {
		[Type(0, "string")]
		public string sessionId = default(string);

		[Type(1, "string")]
		public string username = default(string);
	}
}
