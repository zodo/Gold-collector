namespace FirstStep.Game.States
{
    using Domain.Board;

    using Microsoft.Xna.Framework.Input;

    using Observer;

    /// <summary>
    /// Состояние нахождения в игровом процессе.
    /// </summary>
    public class GameplayState : State, IObserver
    {
        /// <summary>
        /// Игровое поле.
        /// </summary>
        private readonly Board _board;

        /// <summary>
        /// Отображатель доп. инфы.
        /// </summary>
        private readonly Hud _hud;
        
        public GameplayState()
        {
            _board =
                Board.Create(Settings.BoardWidth, Settings.BoardHeight, Settings.Seed)
                    .AddHoles(Settings.HolesAmount)
                    .AddGold(Settings.GoldAmount)
                    .AddRobots(Settings.RobotsAmount, Settings.SmartRobots);
            var gameLogic = new GameLogic(_board);
            gameLogic.AddObserver(this);

            _hud = new Hud();
            gameLogic.AddObserver(_hud);
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
                NewState = new GameOverState(false, _hud);
            }
            if (gameEvent == GameEvent.Victory)
            {
                NewState = new GameOverState(true, _hud);
            }
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public override void Draw()
        {
            _board.Draw();
            _hud.Draw();
        }

        /// <summary>
        /// Выполнить обновление.
        /// </summary>
        protected override void DoUpdate()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                NewState = new PauseState(this);
            }
            _board.Update();
        }
    }
}