import { Command } from "@colyseus/command";
import { MatchState } from "../match.state";

interface OnLeavePayload {
    sessionId: string
}

export class OnLeaveCommand extends Command<MatchState, OnLeavePayload> {

    execute(payload: OnLeavePayload) {
        this.state.players.delete(payload.sessionId)
    }

}