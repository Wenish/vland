import http from "http";
import { Room, Client } from "colyseus";
import logger from "../services/logger.service";
import { MatchState } from "./match.state";
import { Dispatcher } from "@colyseus/command";
import { OnJoinCommand } from "./commands/onJoin.command";
import { OnLeaveCommand } from "./commands/onLeave.command";
import { LoadMapCommand } from "./commands/loadMap.command";

export class MatchRoom extends Room<MatchState> {

    dispatcher: Dispatcher = new Dispatcher(this);

    onCreate(options: any) {
        this.setState(new MatchState())
        this.dispatcher.dispatch(new LoadMapCommand())
        logger(`onCreate ${this.roomName} ${this.roomId}`, 'GameRoom')
        this.onMessage("*", (client, type, message) => {
            logger(`onMessage Client: ${client.sessionId} sent ${type} ${JSON.stringify(message)}`, 'GameRoom')
        });
    }

    onAuth(client: Client, options: any, request: http.IncomingMessage) {
        logger(`onAuth Client: ${client.sessionId}`, 'GameRoom')
        return true;
    }

    onJoin(client: Client, options: any, auth: any) {
        this.dispatcher.dispatch(new OnJoinCommand(), {
            sessionId: client.sessionId
        });
        logger(`onJoin Client: ${client.sessionId}`, 'GameRoom')
    }

    onLeave(client: Client, consented: boolean) {
        this.dispatcher.dispatch(new OnLeaveCommand(), {
            sessionId: client.sessionId
        });
        logger(`onLeave Client with sessionId: ${client.sessionId}`, 'GameRoom')
    }

    onDispose() {
        logger(`onDispose ${this.roomName} ${this.roomId}`, 'GameRoom')
    }
}