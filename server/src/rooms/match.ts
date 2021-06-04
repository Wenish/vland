import http from "http";
import { Room, Client } from "colyseus";
import logger from "../services/logger";

export class RoomMatch extends Room {
    onCreate (options: any) {
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
        logger(`onJoin Client: ${client.sessionId}`, 'GameRoom')
    }

    onLeave (client: Client, consented: boolean) {
        logger(`onLeave Client with sessionId: ${client.sessionId}`, 'GameRoom')
    }

    onDispose () {
        logger(`onDispose ${this.roomName} ${this.roomId}`, 'GameRoom')
    }
}