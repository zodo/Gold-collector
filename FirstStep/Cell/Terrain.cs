namespace FirstStep.Cell
{
    using Microsoft.Xna.Framework.Graphics;

    public class Terrain
    {
        private Texture2D _texture;

        private bool _allowedToMove;

        public Terrain(Texture2D texture, bool allowedToMove)
        {
            _texture = texture;
            _allowedToMove = allowedToMove;
        }
    }
}
