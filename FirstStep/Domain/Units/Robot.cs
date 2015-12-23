namespace FirstStep.Domain.Units
{
    using AI;
    using Board;
    using Game;
    using Microsoft.Xna.Framework;
    using Observer;

    /// <summary>
    /// Робот.
    /// </summary>
    public class Robot : ActiveUnit
    {
        /// <summary>
        /// ИИ робота.
        /// </summary>
        private readonly RobotAI _ai;

        /// <summary>
        /// Заморожен еще на N шагов.
        /// </summary>
        private int _freezeForSteps = -1;

        /// <summary>
        /// Заморожен?
        /// </summary>
        private bool Freezed => _freezeForSteps >= 0;


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
            var size = Settings.CellSizeInPixels;
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * size) + size / 6, (int)(Coordinates.Y * size) + size / 6, size - size / 3, size - size / 3),
                color);
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
                    if (Freezed)
                    {
                        _freezeForSteps--;
                    }
                    else
                    {
                        _ai.NextTurn(this).Execute();
                    }
                }
                if (gameEvent == GameEvent.WeaponUsed)
                {
                    if (Vector2.Distance(Board.Player.Coordinates, Coordinates) < 1.5)
                    {
                        _freezeForSteps = 5;
                    }
                }
            }
        }

        public override bool Act() => true;
    }
}