namespace FirstStep.Domain.Units
{
    using System.Linq;    
    using Board;
    using FirstStep.Commands;
    using Game;
    using Microsoft.Xna.Framework;
    using Observer;

    public class Player : ActiveUnit
    {
        public Player(Board board, Vector2 coords)
            : base(board, coords)
        {
            WeaponCharges = Settings.Charges;
        }

        /// <summary>
        /// Оставшийся заряд оружия.
        /// </summary>
        private int WeaponCharges { get; set; }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
            var command = CommandFactory.Create(this, GetKeysWithoutRepitions());
            var success = command.Execute();
            if (success)
            {
                var playerCoords = Board.Player.Coordinates;
                var touchrobot = Board.Units.OfType<Robot>().Select(x => x.Coordinates).Any(x => x == playerCoords);
                if (touchrobot)
                {
                    Notify(this, GameEvent.PlayerTouchRobot);
                }
                Notify(this, GameEvent.PlayerWalked);
            }
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * 50) + 10, (int)(Coordinates.Y * 50) + 10, 30, 30),
                Color.DarkRed);
        }

        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public override void OnNotify(GameObject obj, GameEvent gameEvent)
        {
        }

        /// <summary>
        /// Применить оружие.
        /// </summary>
        /// <returns>Успешность приминения.</returns>
        public override bool Act()
        {
            if (WeaponCharges > 0)
            {
                Notify(this, GameEvent.WeaponUsed);
                WeaponCharges--;
                return true;
            }
            return false;
        }
    }
}