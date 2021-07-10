// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.25
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class MatchState : Schema {
		[Type(0, "ref", typeof(MapState))]
		public MapState map = new MapState();

		[Type(1, "map", typeof(MapSchema<TeamState>))]
		public MapSchema<TeamState> teams = new MapSchema<TeamState>();

		[Type(2, "map", typeof(MapSchema<PlayerState>))]
		public MapSchema<PlayerState> players = new MapSchema<PlayerState>();

		[Type(3, "map", typeof(MapSchema<UnitState>))]
		public MapSchema<UnitState> units = new MapSchema<UnitState>();
	}
}
