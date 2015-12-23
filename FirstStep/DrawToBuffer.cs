namespace FirstStep
{
    using System;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class DrawToBuffer : GameObject, IDisposable
    {
        public DrawToBuffer(RenderTarget2D buffer)
        {
            Game.SpriteBatch.End();
            Game.GraphicsDevice.SetRenderTarget(buffer);
            Game.GraphicsDevice.Clear(Color.LightGray);
            Game.SpriteBatch.Begin();
        }

        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с удалением, высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            Game.SpriteBatch.End();
            Game.GraphicsDevice.SetRenderTarget(null);
            Game.SpriteBatch.Begin();
        }
    }
}