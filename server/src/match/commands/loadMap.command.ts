import { Command } from "@colyseus/command";
import { CaptureFlagState, CapturePointState, MatchState, PositionState, TeamState } from "../match.state";


interface Position {
    x: number
    y: number
    z: number
}

interface MapFloor {
    width: number
    length: number
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

interface Map {
    mapName: string
    mapFloor: MapFloor
    capturePoints: CapturePoint[]
    captureFlags: CaptureFlag[]
}


interface LoadMapPayload {
    map: Map
    teams: Team[]
}

export class LoadMapCommand extends Command<MatchState, LoadMapPayload> {

    execute({ map, teams }: LoadMapPayload) {
        this.state.map.mapName = map.mapName
        this.state.map.mapFloor.assign({
            width: map.mapFloor.width,
            length: map.mapFloor.length
        })
        teams.forEach((team) => {
            this.state.teams.set(team.id, new TeamState().assign({
                id: team.id,
                color: team.color
            }))
        })

        map.capturePoints.forEach((capturePoint) => {
            this.state.map.capturePoints.set(capturePoint.id, new CapturePointState().assign({
                id: capturePoint.id,
                position: new PositionState().assign({
                    ...capturePoint.position
                }),
                radius: capturePoint.radius
            }))
        })

        map.captureFlags.forEach((captureFlag) => {
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