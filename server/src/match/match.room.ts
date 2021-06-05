import http from "http";
import { Room, Client } from "colyseus";
import logger from "../services/logger.service";
import { CapturePointState, MatchState, PlayerState, PositionState } from "./match.state";

export class MatchRoom extends Room<MatchState> {
    onCreate (options: any) {
        const state = new MatchState()
        // TODO: load map json
        state.map.capturePoints.set('1', new CapturePointState().assign({
            id: '1',
            position: new PositionState().assign({
                x: 10,
                y: 20,
                z: 0
            }),
            radius: 15
        }))
        this.setState(state)
        logger(`onCreate ${this.roomName} ${this.roomId}`, 'GameRoom')
        this.onMessage("*", (client, type, message) => {
            logger(`onMessage Client: ${client.sessionId} sent ${type} ${JSON.stringify(message)}`, 'GameRoom')
        });
    }

    onAuth (client: Client, options: any, request: http.IncomingMessage) {
        logger(`onAuth Client: ${client.sessionId}`, 'GameRoom')
        return true;
    }

    onJoin (client: Client, options: any, auth: any) {
        this.state.players.set(client.sessionId, new PlayerState().assign({
            sessionId: client.sessionId,
            username: `Player ${client.sessionId}`
        }))
        logger(`onJoin Client: ${client.sessionId}`, 'GameRoom')
    }

    onLeave (client: Client, consented: boolean) {
        this.state.players.delete(client.sessionId)
        logger(`onLeave Client with sessionId: ${client.sessionId}`, 'GameRoom')
    }

    onDispose () {
        logger(`onDispose ${this.roomName} ${this.roomId}`, 'GameRoom')
    }
}