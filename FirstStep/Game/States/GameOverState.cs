namespace FirstStep.Game
{
    using Controls;
    using Microsoft.Xna.Framework;
    using States;

    /// <summary>
    /// Состояние нахождения на экране конца игры.
    /// </summary>
    public class GameOverState : State
    {
        /// <summary>
        /// Набор элементов управления.
        /// </summary>
        private readonly ContolCollection _contols;
        
        public GameOverState(bool isVictory, Hud stats)
        {
            var str = isVictory ? "Victory!" : "FAIL";
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(5)
                    .WithBackground(Color.Transparent)
                    .AddHeader(str, 6)
                    .AddHeader(stats.ToString(), 3)
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