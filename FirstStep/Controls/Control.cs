namespace FirstStep.Buttons
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    
    /// <summary>
    /// Базовый класс экранного элемента управления.
    /// </summary>
    public abstract class Control : MainGame.GameObject
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Caption { get; set; }

        protected Control(string caption)
        {
            Caption = caption;
        }

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
        /// Вывести строку, вписав ее в прямоугольник.
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <param name="boundaries">Границы.</param>
        /// <param name="foreground">Цвет.</param>
        protected void DrawString(string str, Rectangle boundaries, Color foreground)
        {
            Vector2 size = Game.Font.MeasureString(str);

            float xScale = (boundaries.Width / size.X);
            float yScale = (boundaries.Height / size.Y);

            float scale = Math.Min(xScale, yScale);

            int strWidth = (int)Math.Round(size.X * scale);
            int strHeight = (int)Math.Round(size.Y * scale);
            Vector2 position = new Vector2();
            position.X = (((boundaries.Width - strWidth) / 2) + boundaries.X);
            position.Y = (((boundaries.Height - strHeight) / 2) + boundaries.Y);

            float rotation = 0.0f;
            Vector2 spriteOrigin = new Vector2(0, 0);
            float spriteLayer = 0.0f;
            SpriteEffects spriteEffects = new SpriteEffects();

            Game.SpriteBatch.DrawString(Game.Font, str, position, foreground, rotation, spriteOrigin, scale, spriteEffects, spriteLayer);
        } 

    }
}
