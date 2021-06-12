// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 1.0.24
// 

using Colyseus.Schema;

namespace GameClient.Models {
	public partial class MapState : Schema {
		[Type(0, "string")]
		public string mapName = default(string);

		[Type(1, "ref", typeof(MapFloorState))]
		public MapFloorState mapFloor = new MapFloorState();

		[Type(2, "map", typeof(MapSchema<CapturePointState>))]
		public MapSchema<CapturePointState> capturePoints = new MapSchema<CapturePointState>();

		[Type(3, "map", typeof(MapSchema<CaptureFlagState>))]
		public MapSchema<CaptureFlagState> captureFlags = new MapSchema<CaptureFlagState>();
	}
}
