import http from "http";
import { Room, Client } from "colyseus";

export class RoomMatch extends Room {
    // When room is initialized
    onCreate (options: any) { }

    // Authorize client based on provided options before WebSocket handshake is complete
    onAuth (client: Client, options: any, request: http.IncomingMessage) {
        return true;
    }

    // When client successfully join the room
    onJoin (client: Client, options: any, auth: any) {
        console.log(`[GameRoom] onJoin Client with sessionId: ${client.sessionId}`)
    }

    // When a client leaves the room
    onLeave (client: Client, consented: boolean) { }

    // Cleanup callback, called after there are no more clients in the room. (see `autoDispose`)
    onDispose () { }
}