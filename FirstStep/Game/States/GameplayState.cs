namespace FirstStep.Game.States
{
    using Board;

    using Microsoft.Xna.Framework.Input;

    using Observer;

    public class GameplayState : SimpleGameObject, IState, IObserver
    {
        private readonly Board _board;

        private readonly GameLogic _gameLogic;

        private readonly StatsCounter _statsCounter;

        private IState _newState;

        public GameplayState()
        {
            _board =
                Board.Create(Settings.BoardWidth, Settings.BoardHeight, Settings.Seed)
                    .AddHoles(Settings.HolesAmount)
                    .AddGold(Settings.GoldAmount)
                    .AddRobots(Settings.RobotsAmount, Settings.SmartRobots);
            _gameLogic = new GameLogic(_board);
            _gameLogic.AddObserver(this);

            _statsCounter = new StatsCounter();
            _gameLogic.AddObserver(_statsCounter);
        }

        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public void OnNotify(SimpleGameObject obj, EventType eventType)
        {
            if (eventType == EventType.GameOver)
            {
                _newState = new GameOverState(false, _statsCounter);
            }
            if (eventType == EventType.Victory)
            {
                _newState = new GameOverState(true, _statsCounter);
            }
        }

        public IState Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return new PauseState(this);
            }
            _board.Update();
            return _newState;
        }

        public void Draw()
        {
            _board.Draw();
            _statsCounter.Draw();
        }
    }
}