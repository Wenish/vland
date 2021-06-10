// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.24
// 

using Colyseus.Schema;

namespace Game.Scripts.Models {
	public partial class UnitState : Schema {
		[Type(0, "string")]
		public string id = default(string);

		[Type(1, "string")]
		public string name = default(string);

		[Type(2, "ref", typeof(PositionState))]
		public PositionState position = new PositionState();

		[Type(3, "number")]
		public float baseMoveSpeed = default(float);

		[Type(4, "number")]
		public float rotation = default(float);

		[Type(5, "number")]
		public float locomotionAnimationSpeedPercent = default(float);

		[Type(6, "boolean")]
		public bool isAlive = default(bool);

		[Type(7, "ref", typeof(BarState))]
		public BarState health = new BarState();

		[Type(8, "ref", typeof(BarState))]
		public BarState shield = new BarState();
	}
}
