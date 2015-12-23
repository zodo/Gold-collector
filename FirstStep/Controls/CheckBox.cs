namespace FirstStep.Controls
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class CheckBox : Control
    {
        /// <summary>
        /// Действие При оповещении.
        /// </summary>
        private readonly Action<bool> _onChange;

        /// <summary>
        /// Отмечен.
        /// </summary>
        private bool _check;

        /// <summary>
        /// Конструктор <see cref="CheckBox"/>
        /// </summary>
        /// <param name="caption">Имя.</param>
        /// <param name="onChange">Действие При оповещении.</param>
        /// <param name="check">Отмечен?</param>
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
    }
}