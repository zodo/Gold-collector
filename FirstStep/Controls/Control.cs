namespace FirstStep.Controls
{
    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Базовый класс экранного элемента управления.
    /// </summary>
    public abstract class Control : SimpleGameObject
    {
        protected Control(string caption)
        {
            Caption = caption;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Обработать нажатые клавиши.
        /// </summary>
        /// <param name="keys"></param>
        public abstract void OnKeysPressed(Keys[] keys);

        /// <summary>
        /// Нарисовать на экране.
        /// </summary>
        /// <param name="coords">Координаты.</param>
        /// <param name="foreground">Цвет переднего плана.</param>
        public abstract void DrawAt(Rectangle coords, Color foreground);

        /// <summary>
        /// Можно ли выбрать контрол.
        /// </summary>
        public abstract bool CanSelect { get; }
    }
}