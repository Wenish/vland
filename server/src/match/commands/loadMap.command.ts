import { Command } from "@colyseus/command";
import { CapturePointState, MatchState, PositionState } from "../match.state";

interface LoadMapPayload {

}

export class LoadMapCommand extends Command<MatchState, LoadMapPayload> {

    execute(payload: LoadMapPayload) {
      this.state.map.capturePoints.set('1', new CapturePointState().assign({
          id: '1',
          position: new PositionState().assign({
              x: 10,
              y: 20,
              z: 0
          }),
          radius: 15
      }))
    }

}