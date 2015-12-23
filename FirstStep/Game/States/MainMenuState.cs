namespace FirstStep.Game.States
{
    using Controls;

    using Microsoft.Xna.Framework;

    using Options;

    /// <summary>
    /// Состояние нахождения в главном меню.
    /// </summary>
    public class MainMenuState : State
    {
        /// <summary>
        /// Набор элентов управления.
        /// </summary>
        private readonly ContolCollection _contols;
        
        public MainMenuState()
        {
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(10)
                    .AddControl(new Button("Play", () => NewState = new GameplayState()))
                    .AddControl(new Button("Options", () => NewState = new OptionsState()))
                    .AddControl(new Button("Quit", () => Game.Exit()))
                    .WithBackground(Color.FromNonPremultiplied(0, 0, 0, 0));
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public override void Draw()
        {
            _contols.Draw();
        }

        /// <summary>
        /// Выполнить обновление.
        /// </summary>
        protected override void DoUpdate()
        {
            _contols.Update();
        }
    }
}