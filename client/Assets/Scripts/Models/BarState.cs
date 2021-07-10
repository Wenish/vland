// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.25
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class BarState : Schema {
		[Type(0, "number")]
		public float current = default(float);

		[Type(1, "number")]
		public float max = default(float);

		[Type(2, "number")]
		public float regenerationSpeed = default(float);
	}
}
