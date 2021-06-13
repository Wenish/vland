import { Command } from "@colyseus/command";
import { CaptureFlagState, CapturePointState, FloorBlockState, FloorBlockTypes, MatchState, PositionState, TeamState } from "../match.state";


interface Position {
    x: number
    y: number
    z: number
}

interface FloorBlock {
    type: FloorBlockTypes,
    position: Position
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
    name: string
    floorBlocks: FloorBlock[]
    capturePoints: CapturePoint[]
    captureFlags: CaptureFlag[]
}


interface LoadMapPayload {
    map: Map
    teams: Team[]
}

export class LoadMapCommand extends Command<MatchState, LoadMapPayload> {

    execute({ map, teams }: LoadMapPayload) {
        this.state.map.name = map.name;
        map.floorBlocks.forEach((floorBlock) => {
            this.state.map.floorBlocks.set(`${floorBlock.position.x}${floorBlock.position.y}${floorBlock.position.z}`, new FloorBlockState().assign({
                type: floorBlock.type,
                position: new PositionState().assign({
                    ...floorBlock.position
                })
            }))
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