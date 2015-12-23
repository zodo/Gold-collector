namespace FirstStep.Domain.AI
{
    using System;
    using System.Linq;

    using Commands;

    using FirstStep.Board;

    using Units;

    public class RobotDumbAI : RobotAI
    {
        private readonly Random _random;

        public RobotDumbAI(Board board)
            : base(board)
        {
            _random = Settings.Seed >= 0? new Random(Settings.Seed) : new Random();
        }

        public override Command NextTurn(Robot robot)
        {
            var cells =
                robot.CurrentCell.CellsAround.Where(x => x.AllowedToMove)
                    .Where(x => !Board.Units.Select(u => u.Coordinates).Contains(x.Coordinates))
                    .ToList();
            var next = cells.OrderBy(x => _random.Next()).FirstOrDefault();
            return CommandFactory.Create(robot, next);
        }
    }
}