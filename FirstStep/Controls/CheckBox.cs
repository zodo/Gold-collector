namespace FirstStep.Controls
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class CheckBox : Control
    {
        private readonly Action<bool> _onChange;

        private bool _check;

        public CheckBox(string caption, Action<bool> onChange, bool check = true)
            : base(caption)
        {
            _onChange = onChange;
            _check = check;
        }

        /// <summary>
        /// Обработать нажатые клавиши.
        /// </summary>
        /// <param name="keys"></param>
        public override void OnKeysPressed(Keys[] keys)
        {
            if (keys.Any(x => x == Keys.Space || x == Keys.Left || x == Keys.Right))
            {
                _check = !_check;
                _onChange(_check);
            }
        }

        /// <summary>
        /// Нарисовать на экране.
        /// </summary>
        /// <param name="coords">Координаты.</param>
        /// <param name="foreground">Цвет переднего плана.</param>
        public override void DrawAt(Rectangle coords, Color foreground)
        {
            DrawString($"   {Caption} : {_check}   ", coords, foreground);
        }

        /// <summary>
        /// Можно ли выбрать контрол.
        /// </summary>
        public override bool CanSelect => true;
    }
}