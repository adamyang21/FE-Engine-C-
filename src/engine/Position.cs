using System;

namespace FEEngine.Engine {
    public class Position {
        //ATTRIBUTES
        private GameMap map;
        private int x;
        private int y;
        private Tile tile;



        //METHODS
        public Position(GameMap map, Tile tile, int x, int y) {
            this.map = map;
            this.tile = tile;
            this.x = x;
            this.y = y;
        }

        //public GameMap getMap()

        public int getX() {
            return this.x;
        }

        public int getY() {
            return this.y;
        }

        public Tile getTile() {
            return tile;
        }

        public void setTile(Tile tile) {
            this.tile = tile;
        }

        //public bool containsActor(Actor actor)

        public char getDisplayCharacter() {
            //if has Actor return Actor displayCharacter
            return this.tile.getDisplayCharacter();
        }
    }
}