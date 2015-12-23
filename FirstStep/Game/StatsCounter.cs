namespace FirstStep.Game
{
    using Microsoft.Xna.Framework;

    using Observer;

    public class StatsCounter : SimpleGameObject, IObserver
    {
        public int PlayerMoves { get; set; }

        public int GoldTaken { get; set; }

        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public void OnNotify(SimpleGameObject obj, EventType eventType)
        {
            if (eventType == EventType.PlayerWalked)
            {
                PlayerMoves++;
            }
            if (eventType == EventType.GoldTaken)
            {
                GoldTaken++;
            }
        }

        public void Draw()
        {
            var width = 200;
            var height = 50;
            var x = Game.Graphics.PreferredBackBufferWidth - width;
            var y = 0;
            var rect = new Rectangle(x, y, width, height);
            Game.SpriteBatch.Draw(Game.WhiteRectangle, rect, Color.FromNonPremultiplied(255,255,255,200));
            DrawString(ToString(), rect, Color.Brown);
        }

        /// <summary>
        /// Возвращает объект <see cref="T:System.String"/>, который представляет текущий объект <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.String"/>, представляющий текущий объект <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return $"Moves: {PlayerMoves} Gold: {GoldTaken}";
        }
    }
}
