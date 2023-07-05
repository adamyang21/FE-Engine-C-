using System;
using FEEngine.Engine;
using FEEngine.Tiles;

namespace FEEngine.Utilities {
    public class TileConverter {
        //ATTRIBUTES
        private static TileConverter instance = null;

        private TileConverter() {}

        public static TileConverter getInstance() {
            if (instance == null) {
                return new TileConverter();
            }
            else {
                return instance;
            }
        }

        public Tile charToTile(char tileCharacter, int height) {
            switch (tileCharacter) {
                case '.':
                    return new Ground(height);
                default:
                    return null;
            }
        }
    }
}