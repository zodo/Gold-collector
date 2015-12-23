namespace FirstStep.Game
{
    using Controls;

    using Microsoft.Xna.Framework;

    using States;

    /// <summary>
    /// Состояние нахождения на экране паузы.
    /// </summary>
    public class PauseState : State
    {
        /// <summary>
        /// Элементы управления.
        /// </summary>
        private readonly ContolCollection _contols;
        
        public PauseState(GameplayState gameState)
        {
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(5)
                    .WithBackground(Color.Transparent)
                    .BeforeUpdate(() => NewState = null)
                    .AddHeader("Pause", 4)
                    .AddControl(new Button("Continue", () => NewState = gameState))
                    .AddControl(new Button("Restart", () => NewState = new GameplayState()))
                    .AddControl(new Button("Main menu", () => NewState = new MainMenuState()));
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