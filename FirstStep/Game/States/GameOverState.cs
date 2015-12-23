namespace FirstStep.Game
{
    using Controls;
    using Microsoft.Xna.Framework;
    using States;

    /// <summary>
    /// Состояние нахождения на экране конца игры.
    /// </summary>
    public class GameOverState : GameObject, IState
    {
        /// <summary>
        /// Набор элементов управления.
        /// </summary>
        private readonly ContolCollection _contols;

        /// <summary>
        /// Новое состояние.
        /// </summary>
        private IState _newState;

        public GameOverState(bool isVictory, Hud stats)
        {
            var str = isVictory ? "WIN" : "FAIL";
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(5)
                    .WithBackground(Color.Transparent)
                    .AddHeader(str, 6)
                    .AddHeader(stats.ToString(), 3)
                    .AddControl(new Button("Restart", () => _newState = new GameplayState()))
                    .AddControl(new Button("Main menu", () => _newState = new MainMenuState()));
        }

        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        public IState Update()
        {
            _contols.Update();
            return _newState;
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public void Draw()
        {
            _contols.Draw();
        }
        
    }
}