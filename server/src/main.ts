import { Server } from "colyseus"
import { RoomMatch } from "./rooms/match";
const port = parseInt(process.env.port, 10) || 3000

const gameServer = new Server()
// Define "match" room
gameServer.define("match", RoomMatch);
gameServer.listen(port)
console.log(`[GameServer] Listening on Port: ${port}`)