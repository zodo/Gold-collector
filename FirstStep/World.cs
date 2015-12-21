namespace FirstStep
{
    using Cell;

    public class World
    {
        private Terrain _ground;

        private Terrain _hole;

        public World()
        {
            _ground = new Terrain(null, true);
            _hole = new Terrain(null, false);
        }
    }
}
