import { Command } from "@colyseus/command";
import { MatchState } from "../match.state";

interface OnLeavePayload {
    sessionId: string
}

export class OnLeaveCommand extends Command<MatchState, OnLeavePayload> {

    execute(payload: OnLeavePayload) {
        const player = this.state.players.get(payload.sessionId)
        this.state.units.delete(player.unitId)
        this.state.players.delete(payload.sessionId)
    }

}