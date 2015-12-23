namespace FirstStep.Domain.AI
{
    using System.Linq;

    using Board.PathFinding;

    using Commands;

    using FirstStep.Board;

    using Units;

    public class RobotSmartAI : RobotAI
    {
        public RobotSmartAI(Board board)
            : base(board)
        {
        }

        public override Command NextTurn(Robot robot)
        {
            var path = PathFinder.GetPath(robot.CurrentCell, Board.Player.CurrentCell, false);
            var next = path.Reverse().Skip(1).FirstOrDefault();
            return CommandFactory.Create(robot, next);
        }
    }
}