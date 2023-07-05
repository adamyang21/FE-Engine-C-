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

        public GameMap getMap() {
            return this.map;
        }

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

        public bool containsActor(Actor actor) {
            return map.positionHasGivenActor(this, actor);
        }

        public char getDisplayCharacter() {
            if (this.map.positionHasActor(this)) {
                Actor actorAtLocation = this.map.getActorAtPosition(this);
                return actorAtLocation.getDisplayCharacter();
            }
            else {
                return this.tile.getDisplayCharacter();
            }
        }
    }
}