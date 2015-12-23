namespace FirstStep.Domain.AI
{
    using Commands;

    using FirstStep.Board;

    using Game;

    using Units;

    public abstract class RobotAI : SimpleGameObject
    {
        protected readonly Board Board;

        public RobotAI(Board board)
        {
            Board = board;
        }

        public abstract Command NextTurn(Robot robot);
    }
}