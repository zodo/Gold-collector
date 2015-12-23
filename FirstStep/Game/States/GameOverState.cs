namespace FirstStep.Game
{
    using System;

    using Controls;

    using Microsoft.Xna.Framework;

    using States;

    public class GameOverState : SimpleGameObject, IState
    {
        private ContolCollection _contolCollection;


        private IState _newState;

        public GameOverState(bool isVictory, StatsCounter stats)
        {
            var str = isVictory ? "WIN" : "FAIL";
            _contolCollection = ContolCollection.Create()
                .AtCoords(ControlPosition.Center)
                .SetSize(5)
                .WithBackground(Color.Transparent)
                .AddLabel(str, 6)
                .AddLabel(stats.ToString(), 3)
                .AddControl(new Button("Restart", () => _newState = new GameplayState()))
                .AddControl(new Button("Main menu", () => _newState = new MainMenuState()));
        }

        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        public IState Update()
        {
            _contolCollection.Update();
            return _newState;
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public void Draw()
        {
            _contolCollection.Draw();
        }

        private Rectangle GetMessageCoords()
        {
            var width = 400;
            var height = 200;
            var x = Game.Graphics.PreferredBackBufferWidth / 2 - width / 2;
            var y = Game.Graphics.PreferredBackBufferHeight / 2 - 100 - height / 2;
            return new Rectangle(x, y, width, height);
            
        }
    }
}