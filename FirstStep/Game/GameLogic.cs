namespace FirstStep.Game
{
    using System.Linq;

    using Board;

    using Domain.Units;

    using Observer;

    using Units;

    public class GameLogic : SimpleGameObject, IObserver
    {
        private readonly Board _board;

        public GameLogic(Board board)
        {
            _board = board;
            _board.Player.AddObserver(this);
            _board.Units.ForEach(u => u.AddObserver(this));
        }

        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public void OnNotify(SimpleGameObject obj, EventType eventType)
        {
            Notify(obj, eventType);

            if (eventType == EventType.GoldTaken)
            {
                if (!_board.Units.OfType<Gold>().Any())
                {
                    Notify(this, EventType.Victory);
                }
            }
            if (eventType == EventType.PlayerWalked)
            {
                if (RobotTouchPlayer())
                {
                    Notify(this, EventType.GameOver);
                }
            }

        }

       
        private bool RobotTouchPlayer()
        {
            var playerCoords = _board.Player.Coordinates;
            return _board.Units.OfType<Robot>().Select(x => x.Coordinates).Any(x => x == playerCoords);
        }
    }
}