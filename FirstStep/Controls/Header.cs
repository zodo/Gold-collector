namespace FirstStep.Controls
{
    using Game;

    /// <summary>
    /// Заголовок контрола.
    /// </summary>
    public class Header : GameObject
    {
        /// <summary>
        /// Конструктор <see cref="Header"/>
        /// </summary>
        /// <param name="caption">Текст.</param>
        /// <param name="size">Размер.</param>
        public Header(string caption, int size = 2)
        {
            Caption = caption;
            Size = size;
        }

        /// <summary>
        /// Отображаемый текст.
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// Размер.
        /// </summary>
        public int Size { get; }
    }
}