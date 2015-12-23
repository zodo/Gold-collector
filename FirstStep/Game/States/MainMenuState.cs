namespace FirstStep.Game.States
{
    using Controls;

    using Microsoft.Xna.Framework;

    using Options;

    /// <summary>
    /// Состояние нахождения в главном меню.
    /// </summary>
    public class MainMenuState : SimpleGameObject, IState
    {
        /// <summary>
        /// Набор элентов управления.
        /// </summary>
        private readonly ContolCollection _contols;

        /// <summary>
        /// Новое состояние.
        /// </summary>
        private IState _newState;

        public MainMenuState()
        {
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(10)
                    .BeforeUpdate(() => _newState = null)
                    .AddControl(new Button("Play", () => _newState = new GameplayState()))
                    .AddControl(new Button("Options", () => _newState = new OptionsState()))
                    .AddControl(new Button("Quit", () => Game.Exit()))
                    .WithBackground(Color.FromNonPremultiplied(0, 0, 0, 0));
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