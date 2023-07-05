using System;
using FEEngine.Engine;
using FEEngine.Utilities;

namespace FEEngine.Engine {
    public class GameMap {
        //ATTRIBUTES
        protected Position[][] map;
        protected int width;
        protected int height;
        protected TileConverter tileConverter = TileConverter.getInstance();
        //protected ActorPositionMapping actorPositions;



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
                for (int j = 0; j < height; j++) {
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
            return this.map[y][x];
        }

        public Tile getTileAt(int x, int y) {
            return this.map[y][x].getTile();
        }

        public void setTileAt(int x, int y, Tile tile) {
            this.map[y][x].setTile(tile);
        }

        //public Actor getActorAt(Position position)

        //public void addActor(Actor actor, Position position)

        //public void removeActor(Actor actor)

        //public void moveActor(Actor actor, Position position)

        //Position getActorLocation(Actor actor)

        //bool locationHasActor(Position position)

        public void tick() {
            //Iterate actors

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