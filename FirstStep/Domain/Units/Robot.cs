namespace FirstStep.Domain.Units
{
    using Actors;

    using AI;

    using FirstStep.Board;
    using FirstStep.Units;

    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

    public class Robot : MoveableUnit
    {
        private readonly RobotAI _ai;

        public Robot(Board board, Vector2 coords, RobotAI ai)
            : base(board, coords)
        {
            _ai = ai;
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
                Color.Red);
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
                    _ai.NextTurn(this).Execute();
                }
            }
        }
    }
}