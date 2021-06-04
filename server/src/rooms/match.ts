import http from "http";
import { Room, Client } from "colyseus";

export class RoomMatch extends Room {
    // When room is initialized
    onCreate (options: any) {
        console.log(`[GameRoom] onCreate ${this.roomName} ${this.roomId}`)
        this.onMessage("*", (client, type, message) => {
            console.log(`[GameRoom] onMessage Client: ${client.sessionId} sent ${type} ${JSON.stringify(message)}`)
        });
    }

    // Authorize client based on provided options before WebSocket handshake is complete
    onAuth (client: Client, options: any, request: http.IncomingMessage) {
        console.log(`[GameRoom] onAuth Client: ${client.sessionId}`)
        return true;
    }

    // When client successfully join the room
    onJoin (client: Client, options: any, auth: any) {
        console.log(`[GameRoom] onJoin Client: ${client.sessionId}`)
    }

    // When a client leaves the room
    onLeave (client: Client, consented: boolean) {
        console.log(`[GameRoom] onLeave Client with sessionId: ${client.sessionId}`)
    }

    // Cleanup callback, called after there are no more clients in the room. (see `autoDispose`)
    onDispose () {
        console.log(`[GameRoom] onDispose ${this.roomName} ${this.roomId}`)
    }
}