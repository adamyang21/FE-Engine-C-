using System;


namespace FEEngine.Engine {
    public class Display {
        private GameMap gameMap;

        public Display() {
            this.gameMap = new GameMap(5, 5, '.');
        }

        public string toString() {
            return this.gameMap.toString();
        }
    }
}