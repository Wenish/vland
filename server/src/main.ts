import { Server } from "colyseus"
import { createServer } from "http";
import express from 'express'
import { monitor } from "@colyseus/monitor";
import { RoomMatch } from "./rooms/match";
import logger from "./services/logger";

const port = parseInt(process.env.port, 10) || 3000
const app = express()
app.use('/colyseus', monitor());
const gameServer = new Server({
    server: createServer(app)
  });
gameServer.define('match', RoomMatch);
gameServer.listen(port)
logger(`Listening on Port: ${port}`, 'GameServer')