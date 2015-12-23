namespace FirstStep.Game.States
{
    using Domain.Board;

    using Microsoft.Xna.Framework.Input;

    using Observer;

    /// <summary>
    /// Состояние нахождения в игровом процессе.
    /// </summary>
    public class GameplayState : GameObject, IState, IObserver
    {
        /// <summary>
        /// Игровое поле.
        /// </summary>
        private readonly Board _board;

        /// <summary>
        /// Игровая логика.
        /// </summary>
        private readonly GameLogic _gameLogic;

        /// <summary>
        /// Отображатель доп. инфы.
        /// </summary>
        private readonly Hud _hud;

        /// <summary>
        /// Новое состояние.
        /// </summary>
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

            _hud = new Hud();
            _gameLogic.AddObserver(_hud);
        }

        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public void OnNotify(GameObject obj, GameEvent gameEvent)
        {
            if (gameEvent == GameEvent.GameOver)
            {
                _newState = new GameOverState(false, _hud);
            }
            if (gameEvent == GameEvent.Victory)
            {
                _newState = new GameOverState(true, _hud);
            }
        }

        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        public IState Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return new PauseState(this);
            }
            _board.Update();
            return _newState;
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public void Draw()
        {
            _board.Draw();
            _hud.Draw();
        }
    }
}