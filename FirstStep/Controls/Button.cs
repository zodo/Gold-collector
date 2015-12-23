namespace FirstStep.Controls
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Кнопка.
    /// </summary>
    public class Button : Control
    {
        /// <summary>
        /// Обработчик нажатия.
        /// </summary>
        private readonly Action _command;

        /// <summary>
        /// Обработчик нажатия с параметром.
        /// </summary>
        private readonly Action<Button> _commandWithArgument;

        /// <summary>
        /// Создать экземпляр <see cref="Button" />.
        /// </summary>
        /// <param name="caption">Имя.</param>
        /// <param name="command">Обработчик нажатия.</param>
        public Button(string caption, Action command)
            : base(caption)
        {
            _command = command;
        }

        /// <summary>
        /// Конструктор <see cref="Button"/>
        /// </summary>
        /// <param name="caption">Имя.</param>
        /// <param name="command">Обработчик нажатия.</param>
        public Button(string caption, Action<Button> command)
            : base(caption)
        {
            _commandWithArgument = command;
        }

        /// <summary>
        /// Обработать нажатые клавиши.
        /// </summary>
        /// <param name="keys"></param>
        public override void OnKeysPressed(Keys[] keys)
        {
            if (!keys.Contains(Keys.Enter))
            {
                return;
            }
            _command?.Invoke();
            _commandWithArgument?.Invoke(this);
        }

        /// <summary>
        /// Нарисовать на экране.
        /// </summary>
        /// <param name="coords">Координаты.</param>
        /// <param name="foreground">Цвет переднего плана.</param>
        public override void DrawAt(Rectangle coords, Color foreground)
        {
            DrawString(Caption, coords, foreground);
        }
    }
}