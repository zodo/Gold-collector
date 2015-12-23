namespace FirstStep.Controls
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Редактор численных значений.
    /// </summary>
    public class NumericUpDown : Control
    {
        /// <summary>
        /// Максимальное значение.
        /// </summary>
        private readonly int _maxValue;

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        private readonly int _minValue;

        /// <summary>
        /// Обработчик изменения значения.
        /// </summary>
        private readonly Action<int> _onChange;

        /// <summary>
        /// Значение.
        /// </summary>
        private int _value;

        /// <summary>
        /// Создать экземпляр <see cref="NumericUpDown" />
        /// </summary>
        /// <param name="caption">Имя.</param>
        /// <param name="onChange">Обработчик изменения значения.</param>
        /// <param name="value">Значение по-умолчанию.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <param name="minValue">Минимальное значение.</param>
        public NumericUpDown(
            string caption,
            Action<int> onChange,
            int value = 0,
            int maxValue = 100500,
            int minValue = 0)
            : base(caption)
        {
            _value = value;
            _maxValue = maxValue;
            _minValue = minValue;
            _onChange = onChange;
        }
        
        /// <summary>
        /// Обработать нажатые клавиши.
        /// </summary>
        /// <param name="keys"></param>
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

        /// <summary>
        /// Нарисовать на экране.
        /// </summary>
        /// <param name="coords">Координаты.</param>
        /// <param name="foreground"></param>
        public override void DrawAt(Rectangle coords, Color foreground)
        {
            //Game.SpriteBatch.Draw(Game.WhiteRectangle, coords, Color.LightSlateGray);
            DrawString($"<- {Caption} : {_value} ->", coords, foreground);
        }
    }
}