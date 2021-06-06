import { Command } from "@colyseus/command";
import { CaptureFlagState, CapturePointState, MatchState, PositionState, TeamState } from "../match.state";


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
        payload.teams.forEach((team) => {
            this.state.map.teams.set(team.id, new TeamState().assign({
                id: team.id,
                color: team.color
            }))
        })

        payload.capturePoints.forEach((capturePoint) => {
            this.state.map.capturePoints.set(capturePoint.id, new CapturePointState().assign({
                id: capturePoint.id,
                position: new PositionState().assign({
                    ...capturePoint.position
                }),
                radius: capturePoint.radius
            }))
        })

        payload.captureFlags.forEach((captureFlag) => {
            this.state.map.captureFlags.set(captureFlag.id, new CaptureFlagState().assign({
                id: captureFlag.id,
                position: new PositionState().assign({
                    ...captureFlag.position
                }),
                teamId: captureFlag.teamId
            }))
        })
    }

}