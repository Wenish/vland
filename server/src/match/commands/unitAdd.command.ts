
import { Command } from "@colyseus/command";
import { MatchState, UnitState } from "../match.state";

interface UnitAddPayload {
    unitId?: string
}

export class UnitAddCommand extends Command<MatchState, UnitAddPayload> {
    execute(payload: UnitAddPayload) {
        const spawnKeys = Array.from(this.state.map.spawns.keys())
        const randomSpawnNumber = Math.floor(Math.random() * spawnKeys.length);
        const spawn = this.state.map.spawns.get( spawnKeys[randomSpawnNumber] )
        const unit = new UnitState().assign({
            position: spawn.position.clone()
        })
        unit.id = payload.unitId || unit.id
        this.state.units.set(unit.id, unit)
    }
}