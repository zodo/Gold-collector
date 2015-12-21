namespace FirstStep.Base
{
    using System;
    using System.Linq;

    using Buttons;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Observer;

    public class Button : Control
    {
        private readonly Action _command;

        public Button(string name, Action command) : base(name)
        {
            _command = command;
        }

        public override void OnKeysPressed(Keys[] keys)
        {
            if (keys.Contains(Keys.Enter))
            {
                _command();
            }
        }

        public override void DrawAt(Rectangle coords)
        {
            Game.SpriteBatch.Draw(Game.WhiteRectangle, coords, Color.LightSlateGray);
            Game.SpriteBatch.DrawString(Game.Font, _name, new Vector2(coords.X, coords.Y), Color.Black);
        }
    }
}
