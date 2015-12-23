namespace FirstStep.Game
{
    using Controls;

    using Microsoft.Xna.Framework;

    using States;

    /// <summary>
    /// Состояние нахождения на экране паузы.
    /// </summary>
    public class PauseState : GameObject, IState
    {
        /// <summary>
        /// Элементы управления.
        /// </summary>
        private readonly ContolCollection _contols;

        /// <summary>
        /// Новое состояние.
        /// </summary>
        private IState _newState;

        public PauseState(GameplayState gameState)
        {
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(5)
                    .WithBackground(Color.Transparent)
                    .AddHeader("Pause", 4)
                    .AddControl(new Button("Continue", () => _newState = gameState))
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