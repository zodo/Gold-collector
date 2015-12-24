namespace FirstStep.Game
{
    using System.Linq;

    using Domain.Board;
    using Domain.Units;

    using Observer;

    /// <summary>
    /// Игровая логика.
    /// </summary>
    public class GameLogic : GameObject, IObserver
    {
        /// <summary>
        /// Игровое поле.
        /// </summary>
        private readonly Board _board;

        public GameLogic(Board board)
        {
            _board = board;
            _board.Player.AddObserver(this);
            _board.Units.ForEach(u => u.AddObserver(this));
        }

        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public void OnNotify(GameObject obj, GameEvent gameEvent)
        {
            Notify(obj, gameEvent);

            if (gameEvent == GameEvent.GoldTaken)
            {
                if (!_board.Units.OfType<Gold>().Any())
                {
                    Notify(this, GameEvent.Victory);
                }
            }

            if (gameEvent == GameEvent.PlayerTouchRobot)
            {
                Notify(this, GameEvent.GameOver);
            }
        }
    }
}