import { MapSchema, Schema, type } from "@colyseus/schema"

export class PositionState extends Schema {
    @type('number') x: number = 0
    @type('number') y: number = 0
    @type('number') z: number = 0
}

export class CapturePointState extends Schema {
    @type('string') id: string
    @type(PositionState) position: PositionState
    @type('number') radius: number
}

export class MapSizeState extends Schema {
    @type('number') width: number = 100
    @type('number') height: number = 200
}

export class MapState extends Schema {
    @type('string') mapName: string = 'cs_default'
    @type(MapSizeState) mapSize: MapSizeState = new MapSizeState()
    @type({ map: CapturePointState }) capturePoints = new MapSchema<CapturePointState>()
}

export class TeamState extends Schema {
    @type('string') id: string
    @type('string') color: string
    @type('number') score: number = 0
}

export class PlayerState extends Schema {
    @type('string') sessionId: string
    @type('string') username: string = 'Player'
}

export class BarState extends Schema {
    @type('number') current: number
    @type('number') max: number
    @type('number') regenerationSpeed: number
}

export class UnitState extends Schema {
    @type('string') id: string
    @type('string') name: string = 'Unit Name'
    @type(PositionState) position: PositionState
    @type('number') baseMoveSpeed: number
    @type('number') rotation: number
    @type('number') locomotionAnimationSpeedPercent: number
    @type('boolean') isAlive: boolean
    @type(BarState) health: BarState
    @type(BarState) shield: BarState

}

export class MatchState extends Schema {
    @type(MapState) map: MapState = new MapState()
    @type({ map: TeamState }) teams = new MapSchema<TeamState>()
    @type({ map: PlayerState }) players = new MapSchema<PlayerState>()
    @type({ map: UnitState }) units = new MapSchema<UnitState>()
}