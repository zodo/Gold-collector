namespace FirstStep.Base
{
    using System.Collections.Generic;
    using System.Linq;

    using Buttons;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class ContolCollection : GoldGame.GameObject
    {
        private int _selected;

        private const int BaseSize = 50;

        public readonly List<Control> Contols = new List<Control>(); 
        
        private ContolCollection() { }

        public Vector2 Coordinates { get; set; }

        public double Size { get; set; }

        private Keys[] _previouslyPressed = new Keys[0];

        public static ControlCollectionBuilder Create()
        {
            return new ControlCollectionBuilder(new ContolCollection());
        }

        private void Down()
        {
            _selected++;
            if (_selected >= Contols.Count)
            {
                _selected = 0;
            }
        }

        private void Up()
        {
            _selected--;
            if (_selected < 0)
            {
                _selected = Contols.Count - 1;
            }
        }

        public void Update()
        {
            var keysPressed = Keyboard.GetState().GetPressedKeys();
            var firstTime = keysPressed.Except(_previouslyPressed).ToArray();
            if (firstTime.Contains(Keys.Down))
            {
                Down();
            }
            if (firstTime.Contains(Keys.Up))
            {
                Up();
            }
            Contols[_selected].OnKeysPressed(firstTime);
            
            _previouslyPressed = keysPressed;
        }

        public void Draw()
        {
            var width = (int)(Size * BaseSize);
            var height = (int)(Contols.Count * Size * BaseSize / 5);
            var x = (int)(Coordinates.X -  width / 2);
            var y = (int)(Coordinates.Y - height / 2);
            
            Game.SpriteBatch.Draw(Game.WhiteRectangle, new Rectangle(x, y, width, height), Color.LightGray);

            for (int i = 0; i < Contols.Count; i++)
            {
                var ctrlX = x + Size;
                var ctrlY = y + i * Size * BaseSize / 5 + Size;
                var ctrlH = Size * BaseSize / 5 - Size * 2;

                Contols[i].DrawAt(new Rectangle((int)ctrlX, (int)ctrlY, width, (int)ctrlH));

                if (i == _selected)
                {
                    Game.SpriteBatch.Draw(Game.WhiteRectangle, new Rectangle((int)ctrlX, (int)(ctrlY +ctrlH - Size), width, (int)Size), Color.White);
                }
            }
        }
    }
}
