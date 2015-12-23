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
            
                if (eventType == EventType.GoldTaken)
                {
                    _board.Units.Remove(_board.Units.SingleOrDefault(x => x.Coordinates == _board.Player.Coordinates));
                    if (!_board.Units.OfType<Gold>().Any())
                    {
                        Notify(this, EventType.Victory);
                        return;
                    }
                    
                    Notify(this, EventType.GoldTaken);
                }
                if (eventType == EventType.PlayerWalked)
                {
                    UpdateGameLogic();
                }
                if (eventType == EventType.GameOver)
                {
                    Notify(this, EventType.GameOver);
                }
            
        }

        private void UpdateGameLogic()
        {
            if (RobotTouchPlayer())
            {
                Notify(this, EventType.GameOver);
                return;
            }
            
            Notify(this, EventType.PlayerWalked);
        }

        private bool RobotTouchPlayer()
        {
            var playerCoords = _board.Player.Coordinates;
            return _board.Units.OfType<Robot>().Select(x => x.Coordinates).Any(x => x == playerCoords);
        }

        private bool PlayerTakeGold()
        {
            var playerCoords = _board.Player.Coordinates;
            return _board.Units.OfType<Gold>().Select(x => x.Coordinates).Any(x => x == playerCoords);
        }
    }
}