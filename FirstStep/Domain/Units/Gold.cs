namespace FirstStep.Domain.Units
{
    using FirstStep.Board;
    using FirstStep.Units;

    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

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
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * 50) + 10, (int)(Coordinates.Y * 50) + 10, 30, 30),
                Color.Gold);
        }

        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public override void OnNotify(SimpleGameObject obj, EventType eventType)
        {
            if (obj is Player)
            {
                if (eventType == EventType.PlayerWalked)
                {
                    if (Board.Player.Coordinates == Coordinates)
                    {
                        Board.Units.Remove(this);
                        Board.Player.RemoveObserver(this);
                        Notify(this, EventType.GoldTaken);
                    }
                }
            }
        }
    }
}