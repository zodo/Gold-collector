namespace FirstStep.Units
{
    using System.Linq;

    using Actors;

    using Board;

    using Commands;

    using Domain.Units;

    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

    public class Player : ActiveUnit
    {
        public int WeaponCharges { get; set; }

        public Player(Board board, Vector2 coords)
            : base(board, coords)
        {
            WeaponCharges = Settings.Charges;
        }

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
                    Notify(this, EventType.GameOver);
                }
                Notify(this, EventType.PlayerWalked);
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
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public override void OnNotify(SimpleGameObject obj, EventType eventType)
        {
        }

        public override bool Act()
        {
            if (WeaponCharges > 0)
            {
                Notify(this, EventType.WeaponUsed);
                WeaponCharges--;
                return true;
            }
            return false;
        }
    }
}