import { Schema, type } from "@colyseus/schema"

class MapSizeState extends Schema {
    @type('number') width: number = 100
    @type('number') height: number = 200
}

class MapState extends Schema {
    @type('string') mapName: string = 'cs_default'
    @type(MapSizeState) mapSizeState: MapSizeState = new MapSizeState()
}

export class MatchState extends Schema {
    @type(MapState) mapName: MapState = new MapState()
}