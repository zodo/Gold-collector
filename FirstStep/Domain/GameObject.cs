namespace FirstStep
{
    using System;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Observer;


    /// <summary>
    /// Игровой объект.
    /// </summary>
    public abstract class GameObject : MainGame.InnerGameObject
    {
        /// <summary>
        /// Вывести строку, вписав ее в прямоугольник.
        /// </summary>
        /// <param name="str">Строка.</param>
        /// <param name="boundaries">Границы.</param>
        /// <param name="foreground">Цвет.</param>
        protected void DrawString(string str, Rectangle boundaries, Color foreground)
        {
            var size = Game.Font.MeasureString(str);

            var xScale = (boundaries.Width / size.X);
            var yScale = (boundaries.Height / size.Y);

            var scale = Math.Min(xScale, yScale);

            var strWidth = (int)Math.Round(size.X * scale);
            var strHeight = (int)Math.Round(size.Y * scale);
            var position = new Vector2();
            position.X = (((boundaries.Width - strWidth) / 2) + boundaries.X);
            position.Y = (((boundaries.Height - strHeight) / 2) + boundaries.Y);

            var rotation = 0.0f;
            var spriteOrigin = new Vector2(0, 0);
            var spriteLayer = 0.0f;
            var spriteEffects = new SpriteEffects();

            Game.SpriteBatch.DrawString(
                Game.Font,
                str,
                position,
                foreground,
                rotation,
                spriteOrigin,
                scale,
                spriteEffects,
                spriteLayer);
        }
    }

    /// <summary>
    /// Основной тип с игровым циклом.
    /// </summary>
    public partial class MainGame
    {
        /// <summary>
        /// Внутренний класс для доступа к приватным данным <see cref="MainGame"/>
        /// </summary>
        public abstract class InnerGameObject : Subject
        {
            /// <summary>
            /// Игра.
            /// </summary>
            protected MainGame Game => _instance;

            /// <summary>
            /// Настройки.
            /// </summary>
            protected GameSettings Settings
            {
                get
                {
                    return _settings;
                }
                set
                {
                    _settings = value;
                }
            }
        }
    }
}