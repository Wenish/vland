import { Server } from "colyseus"
import { RoomMatch } from "./rooms/match";
import logger from "./services/logger";

const port = parseInt(process.env.port, 10) || 3000
const gameServer = new Server()
// Define "match" room
gameServer.define("match", RoomMatch);
gameServer.listen(port)
logger(`Listening on Port: ${port}`, 'GameServer')