namespace FirstStep.Domain.AI
{
    using System.Linq;

    using Board;
    using Board.PathFinding;

    using Commands;

    using Units;

    /// <summary>
    /// ИИ с поиском пути.
    /// </summary>
    public class RobotSmartAI : RobotAI
    {
        public RobotSmartAI(Board board)
            : base(board)
        {
        }

        /// <summary>
        /// Получить инструкцию.
        /// </summary>
        public override Command NextTurn(Robot robot)
        {
            var path = PathFinder.GetPath(robot.CurrentCell, Board.Player.CurrentCell, false);
            var next = path.Reverse().Skip(1).FirstOrDefault();
            return CommandFactory.Create(robot, next);
        }
    }
}