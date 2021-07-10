import { Command } from "@colyseus/command";
import { MatchState, PlayerState } from "../match.state";

interface OnJoinPayload {
    sessionId: string
    unitId: string
}

export class OnJoinCommand extends Command<MatchState, OnJoinPayload> {

    execute(payload: OnJoinPayload) {
        this.state.players.set(payload.sessionId, new PlayerState().assign({
            sessionId: payload.sessionId,
            username: `Player ${payload.sessionId}`,
            unitId: payload.unitId
        }))
    }

}