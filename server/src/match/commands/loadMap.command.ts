import { Command } from "@colyseus/command";
import { CapturePointState, MatchState, PositionState } from "../match.state";


interface Position {
    x: number
    y: number
    z: number
}

interface MapSize {
    width: number
    height: number
}

interface Team {
    id: string
    color: string
}

interface CapturePoint {
    id: string
    position: Position
    radius: number
}

interface CaptureFlag {
    id: string
    position: Position
    teamId: string
}


interface LoadMapPayload {
    mapName: string
    mapSize: MapSize
    teams: Team[]
    capturePoints: CapturePoint[]
    captureFlags: CaptureFlag[]
}

export class LoadMapCommand extends Command<MatchState, LoadMapPayload> {

    execute(payload: LoadMapPayload) {
        this.state.map.mapName = payload.mapName
        this.state.map.mapSize.assign({
            width: payload.mapSize.width,
            height: payload.mapSize.height
        })

        console.log(payload)
        this.state.map.capturePoints.set('1', new CapturePointState().assign({
            id: '1',
            position: new PositionState().assign({
                x: 10,
                y: 20,
                z: 0
            }),
            radius: 15
        }))
    }

}