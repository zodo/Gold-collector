namespace FirstStep
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Отрисовщик во временный буфер.
    /// </summary>
    public class DrawToBuffer : GameObject, IDisposable
    {
        /// <summary>
        /// Начать отрисовку во временный буфер.
        /// </summary>
        /// <param name="buffer">Временный буфер.</param>
        public DrawToBuffer(RenderTarget2D buffer)
        {
            Game.SpriteBatch.End();
            Game.GraphicsDevice.SetRenderTarget(buffer);
            Game.GraphicsDevice.Clear(Color.Transparent);
            Game.SpriteBatch.Begin();
        }

        /// <summary>
        /// Закончить отрисовку во временнный буфер.
        /// </summary>
        public void Dispose()
        {
            Game.SpriteBatch.End();
            Game.GraphicsDevice.SetRenderTarget(null);
            Game.SpriteBatch.Begin();
        }
    }
}