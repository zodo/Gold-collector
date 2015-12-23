namespace FirstStep.Game
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Простой игровой объект.
    /// </summary>
    /// <remarks>Просто обертка над <see cref="MainGame.GameObject" /></remarks>
    public abstract class SimpleGameObject : MainGame.GameObject
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
}