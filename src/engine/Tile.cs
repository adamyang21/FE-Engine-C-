using System;


namespace FEEngine.Engine {
    public abstract class Tile {
        //ATTRIBUTES
        private char displayCharacter;
        private bool collision;
        private int height;



        //METHODS
        public Tile(char displayCharacter, bool collision, int height) {
            this.displayCharacter = displayCharacter;
            this.collision = collision;
            this.height = height;
        }

        public char getDisplayCharacter() {
            return this.displayCharacter;
        }

        public bool getCollision() {
            return this.collision;
        }

        public int getHeight() {
            return this.height;
        }

        public abstract void tick();
    }
}
