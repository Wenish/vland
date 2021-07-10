
import { Command } from "@colyseus/command";
import { MatchState, UnitState } from "../match.state";

interface UnitAddPayload {

}

export class UnitAddCommand extends Command<MatchState, UnitAddPayload> {
    execute(payload: UnitAddPayload) {
        const spawnsSize = this.state.map.spawns.size
        const randomSpawnNumber = (Math.floor(Math.random() * spawnsSize))
        const spawnKey = this.state.map.spawns['$indexes'].get(randomSpawnNumber)
        const spawn = this.state.map.spawns.get(spawnKey)
        const unit = new UnitState().assign({
            position: spawn.position.clone()
        })
        this.state.units.set(unit.id, unit)
    }
}