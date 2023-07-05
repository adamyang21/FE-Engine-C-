using System;
using FEEngine.Actors;
using FEEngine.Engine;
using FEEngine.Utilities;
using FEEngine.Enums;

namespace FEEngine.Engine {
    public class GameMap {
        //ATTRIBUTES
        protected Position[][] map;
        protected int width;
        protected int height;
        protected TileConverter tileConverter = TileConverter.getInstance();
        protected ActorPositionMapping actorPositions = new ActorPositionMapping();
        protected Dictionary<string, AllyUnit> playerUnits = new Dictionary<string, AllyUnit>();



        //METHODS
        public GameMap(string[] mapStrings) {
            createMapFromStrings(mapStrings);
        }

        public GameMap(int width, int height, char tileCharacter) {
            this.width = width;
            this.height = height;

            this.map = new Position[height][];
            for (int i = 0; i < height; i++) {
                this.map[i] = new Position[width];
                for (int j = 0; j < width; j++) {
                    this.map[i][j] = new Position(this, tileConverter.charToTile(tileCharacter, 0), j, i);
                }
            }
        }

        //public GameMap(string mapFile)

        private void createMapFromStrings(string[] mapStrings) {
            this.width = mapStrings[0].Length;
            this.height = mapStrings.Length;

            this.map = new Position[height][];
            for (int i = 0; i < height; i++) {
                this.map[i] = new Position[width];
                for (int j = 0; j < width; j++) {
                    this.map[i][j] = new Position(this, tileConverter.charToTile(mapStrings[i][j], 0), j, i);
                }
            }
        }

        public Position getPositionAt(int x, int y) {
            try {
                return this.map[y][x];
            }
            catch (Exception e) {
                return null;
            }
        }

        public Tile getTileAt(int x, int y) {
            return this.map[y][x].getTile();
        }

        public void setTileAt(int x, int y, Tile tile) {
            this.map[y][x].setTile(tile);
        }

        public Actor getActorAtPosition(Position position) {
            return this.actorPositions.getActorAtPosition(position);
        }

        public void addActor(Actor actor, Position position) {
            this.actorPositions.addActor(actor, position);
        }

        public void removeActor(Actor actor) {
            this.actorPositions.removeActor(actor);
        }

        public void moveActor(Actor actor, Position position) {
            this.actorPositions.moveActor(actor, position);
        }

        public void addPlayerUnit(AllyUnit actor, Position position) {
            this.playerUnits[actor.getName()] = actor;
            addActor(actor, position);
        }

        public void removePlayerUnit(AllyUnit actor) {
            this.playerUnits.Remove(actor.getName());
            removeActor(actor);
        }

        public void movePlayerUnit(string name, Position position) {
            AllyUnit playerUnit = this.playerUnits[name];
            moveActor(playerUnit, position);
        }

        public Position getActorLocation(Actor actor) {
            return this.actorPositions.getActorLocation(actor);
        }

        public bool positionHasActor(Position position) {
            return this.actorPositions.locationHasActor(position);
        }

        public bool positionHasGivenActor(Position position, Actor actor) {
            return this.actorPositions.positionHasGivenActor(position, actor);
        }

        public void tick() {
            this.actorPositions.tickActors();

            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    this.map[i][j].getTile().tick();
                }
            }
        }

        public string toString() {
            string res = "";
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    res += this.map[i][j].getDisplayCharacter();
                }
                res += "\n";
            }
            return res;
        }
    }
}