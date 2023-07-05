using FEEngine.Engine;

namespace FEEngine.Tiles {
    public class Ground : Tile {
        //METHODS
        public Ground(int height) : base('.', false, height) {}

        public override void tick() {}
    }
}