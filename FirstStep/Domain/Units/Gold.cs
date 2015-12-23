namespace FirstStep.Domain.Units
{
    using Board;
    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

    /// <summary>
    /// Золото.
    /// </summary>
    public class Gold : Unit
    {
        public Gold(Board board, Vector2 coords)
            : base(board, coords)
        {
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            var size = Settings.CellSizeInPixels;
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * size) + size / 6, (int)(Coordinates.Y * size) + size / 6, size - size / 3, size - size / 3),
                Color.Gold);
        }

        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public override void OnNotify(GameObject obj, GameEvent gameEvent)
        {
            if (obj is Player)
            {
                if (gameEvent == GameEvent.PlayerWalked)
                {
                    if (Board.Player.Coordinates == Coordinates)
                    {
                        Board.Units.Remove(this);
                        Board.Player.RemoveObserver(this);
                        Notify(this, GameEvent.GoldTaken);
                    }
                }
            }
        }
    }
}