namespace FirstStep.Game.States
{
    public interface IState
    {
        IState Update();
        void Draw();
    }
}
