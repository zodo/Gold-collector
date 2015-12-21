namespace FirstStep.Game.States
{
    using System.Diagnostics;

    using Base;

    using Buttons;

    using Microsoft.Xna.Framework;

    using Observer;

    using Play;

    public class MainMenuState : GoldGame.GameObject, IState
    {
        private ContolCollection _contols;

        private IState _newState;

        public MainMenuState()
        {
            _contols = ContolCollection
                .Create()
                .AtCoords(new Vector2(512, 384))
                .WithSize(10)
                .AddControl(new Button("Play", () => _newState = new GameplayState()))
                .AddControl(new Button("Options", () => _newState = new MainMenuState()))
                .AddControl(new NumericUpDown("Test", i => Debug.WriteLine(i)))
                .AddControl(new Button("Quit", () => Game.Exit()));
        }


        public IState Update()
        {
            _newState = null;
            _contols.Update();
            return _newState;
        }

        public void Draw()
        {
            _contols.Draw();
        }
        
    }
}
