import shortid from 'shortid'
import { MapSchema, Schema, type } from "@colyseus/schema"
import NavMesh from "navmesh"

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

export class CaptureFlagState extends Schema {
    @type('string') id: string
    @type(PositionState) position: PositionState
    @type('string') teamId: string
}

export enum FloorBlockTypes {
    BlockGrass = 'Grass',
    BlockDirt = 'Dirt',
    BlockSnow = 'Snow',
    BlockBridge = 'Bridge'
}

export class FloorBlockState extends Schema {
    @type('string') type: FloorBlockTypes
    @type(PositionState) position: PositionState
}

export class TeamState extends Schema {
    @type('string') id: string
    @type('string') color: string
    @type('number') score: number = 0
}

export class SpawnState extends Schema {
    @type(PositionState) position: PositionState
}

export class MapState extends Schema {
    @type('string') name: string
    @type({ map: FloorBlockState }) floorBlocks = new MapSchema<FloorBlockState>()
    @type({ map: CapturePointState }) capturePoints = new MapSchema<CapturePointState>()
    @type({ map: CaptureFlagState }) captureFlags = new MapSchema<CaptureFlagState>()
    @type({ map: SpawnState }) spawns = new MapSchema<SpawnState>()
}

export class PlayerState extends Schema {
    @type('string') sessionId: string
    @type('string') username: string = 'Player'
    @type('string') unitId: string
}

export class BarState extends Schema {
    @type('number') current: number
    @type('number') max: number
    @type('number') regenerationSpeed: number
}

export class UnitState extends Schema {
    @type('string') id: string = shortid.generate()
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

    navMesh: NavMesh;
}