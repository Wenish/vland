import { Command } from "@colyseus/command";
import { CaptureFlagState, CapturePointState, FloorBlockState, FloorBlockTypes, MatchState, PositionState, SpawnState } from "../match.state";

import * as NavMesh from 'navmesh'

interface Position {
    x: number
    y: number
    z: number
}

interface FloorBlock {
    type: FloorBlockTypes,
    position: Position
}

interface CapturePoint {
    position: Position
    radius: number
}

interface CaptureFlag {
    position: Position
    teamId: string
}

interface Spawn {
    position: Position
}

interface Map {
    name: string
    floorBlocks: { [key: string]: FloorBlock; }
    capturePoints: { [key: string]: CapturePoint; }
    captureFlags: { [key: string]: CaptureFlag; }
    spawns: { [key: string]: Spawn }
}

interface Grid {
    width: number
    height: number
}


interface LoadMapPayload {
    map: Map
    grid: Grid
}

export class LoadMapCommand extends Command<MatchState, LoadMapPayload> {

    execute(payload: LoadMapPayload) {
        const gridWidth = 5 || payload.grid.width
        const gridHeight = 4 || payload.grid.height
        const matrix2d = new Array(gridHeight).fill(0).map((value, index) => {
            return new Array(gridWidth).fill(index).map((value, index) => {
                return (value * gridWidth) + index + 1
            })
        });
        console.log(matrix2d)
        const meshPolygonPoints = NavMesh.buildPolysFromGridMap<number>(matrix2d)
        console.log(meshPolygonPoints)
        const navMesh = new NavMesh.NavMesh(meshPolygonPoints);

        this.state.map.name = payload.map.name;
        Object.keys(payload.map.floorBlocks).forEach((key) => {
            const floorBlock = payload.map.floorBlocks[key]
            this.state.map.floorBlocks.set(key, new FloorBlockState().assign({
                type: floorBlock.type,
                position: new PositionState().assign({
                    ...floorBlock.position
                })
            }))
        })

        Object.keys(payload.map.capturePoints).forEach((key) => {
            const capturePoint = payload.map.capturePoints[key]
            this.state.map.capturePoints.set(key, new CapturePointState().assign({
                id: key,
                position: new PositionState().assign({
                    ...capturePoint.position
                }),
                radius: capturePoint.radius
            }))
        })

        Object.keys(payload.map.captureFlags).forEach((key) => {
            const captureFlag = payload.map.captureFlags[key]
            this.state.map.captureFlags.set(key, new CaptureFlagState().assign({
                id: key,
                position: new PositionState().assign({
                    ...captureFlag.position
                }),
                teamId: captureFlag.teamId
            }))
        })

        Object.keys(payload.map.spawns).forEach((key) => {
            const spawn = payload.map.spawns[key]
            this.state.map.spawns.set(key, new SpawnState().assign({
                position: new PositionState().assign({
                    ...spawn.position
                })
            }))
        })
    }

}