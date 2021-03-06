import { Server } from "colyseus"
import { createServer } from "http";
import express from 'express'
import { monitor } from "@colyseus/monitor";
import { MatchRoom } from "./match/match.room";
import logger from "./services/logger.service";

const port = parseInt(process.env.PORT, 10) || 3000
const app = express()
app.use('/colyseus', monitor());
app.get('/', function (req, res) {
  res.send('200 OK')
})
const gameServer = new Server({
    server: createServer(app)
  });
gameServer.define('match', MatchRoom);
gameServer.listen(port)
logger(`Listening on Port: ${port}`, 'GameServer')
logger(`Check Rooms at: http://localhost:${port}/colyseus`, 'GameServer')