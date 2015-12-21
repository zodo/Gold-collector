namespace FirstStep.Buttons
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class NumericUpDown : Control
    {
       
        private readonly int _maxValue;

        private readonly int _minValue;

        private readonly Action<int> _onChange;

        private int _value;

        public NumericUpDown(string name, Action<int> onChange, int value = 0, int maxValue = 100500, int minValue = 0) : base(name)
        {
            _value = value;
            _maxValue = maxValue;
            _minValue = minValue;
            _onChange = onChange;
        }

        public override void OnKeysPressed(Keys[] keys)
        {
            if (keys.Contains(Keys.Left))
            {
                _value--;
                if (_value < _minValue)
                {
                    _value = _minValue;
                }
                _onChange(_value);
            }
            if (keys.Contains(Keys.Right))
            {
                _value++;
                if (_value > _maxValue)
                {
                    _value = _maxValue;
                }
                _onChange(_value);
            }
        }

        public override void DrawAt(Rectangle coords)
        {
            Game.SpriteBatch.Draw(Game.WhiteRectangle, coords, Color.LightSlateGray);
            Game.SpriteBatch.DrawString(Game.Font, $"{_name} : {_value}", new Vector2(coords.X, coords.Y), Color.Black);
        }
    }
}
