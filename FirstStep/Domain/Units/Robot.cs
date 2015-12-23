namespace FirstStep.Domain.Units
{
    using System;

    using Actors;

    using AI;

    using FirstStep.Board;
    using FirstStep.Units;

    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

    public class Robot : ActiveUnit
    {
        private readonly RobotAI _ai;

        private int _freezeForSteps = -1;

        public bool Freezed => _freezeForSteps >= 0;

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
            var color = Freezed ? Color.Blue : Color.Red;
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * 50) + 10, (int)(Coordinates.Y * 50) + 10, 30, 30),
                color);
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
                    if (Freezed)
                    {
                        _freezeForSteps--;
                    }
                    else
                    {
                        _ai.NextTurn(this).Execute();
                    }
                }
                if (eventType == EventType.WeaponUsed)
                {
                    if (Vector2.Distance(Board.Player.Coordinates, Coordinates) < 1.5)
                    {
                        _freezeForSteps = 5;
                    }
                }
            }
        }

        public override bool Act()
        {
            return true;
        }
    }
}