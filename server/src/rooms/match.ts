import http from "http";
import { Room, Client } from "colyseus";

export class RoomMatch extends Room {
    onCreate (options: any) {
        console.log(`[GameRoom] onCreate ${this.roomName} ${this.roomId}`)
        this.onMessage("*", (client, type, message) => {
            console.log(`[GameRoom] onMessage Client: ${client.sessionId} sent ${type} ${JSON.stringify(message)}`)
        });
    }

    onAuth (client: Client, options: any, request: http.IncomingMessage) {
        console.log(`[GameRoom] onAuth Client: ${client.sessionId}`)
        return true;
    }

    onJoin (client: Client, options: any, auth: any) {
        console.log(`[GameRoom] onJoin Client: ${client.sessionId}`)
    }

    onLeave (client: Client, consented: boolean) {
        console.log(`[GameRoom] onLeave Client with sessionId: ${client.sessionId}`)
    }

    onDispose () {
        console.log(`[GameRoom] onDispose ${this.roomName} ${this.roomId}`)
    }
}