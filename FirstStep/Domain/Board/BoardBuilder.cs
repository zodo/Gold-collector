namespace FirstStep.Board
{
    using System;
    using System.Linq;

    using Domain.AI;
    using Domain.Board.PathFinding;
    using Domain.Units;

    using Microsoft.Xna.Framework;

    using Units;

    public class BoardBuilder
    {
        private readonly Board _board;

        private readonly Random _random;

        public BoardBuilder(Board board, int seed = -1)
        {
            _board = board;
            _board.Player = new Player(_board, new Vector2(_board.Width / 2, _board.Height / 2));
            _random = seed >= 0 ? new Random(seed) : new Random();
        }

        public BoardBuilder AddHoles(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var freeCells = _board.Where(CanPlaceHole).ToList();

                if (!freeCells.Any())
                {
                    break;
                }

                var index = _random.Next(freeCells.Count);
                var cell = freeCells[index];
                _board[cell.Coordinates] = new Cell(_board, cell.Coordinates, false);
            }
            return this;
        }

        public BoardBuilder AddGold(int amount)
        {
            var possibleCells =
                _board.Where(x => x.AllowedToMove)
                    .Where(x => !_board.Units.Select(u => u.Coordinates).Contains(x.Coordinates))
                    .Where(x => _board.Player.Coordinates != x.Coordinates)
                    .Where(x => PathFinder.CanReach(x, _board.Player.CurrentCell))
                    .ToList();
            var gold =
                possibleCells.OrderBy(x => _random.Next())
                    .Take(amount)
                    .Select(x => new Gold(_board, x.Coordinates))
                    .ToList();
            _board.Units.AddRange(gold);
            return this;
        }

        public BoardBuilder AddRobots(int amount, bool isSmart = true)
        {
            var possibleCells =
                _board.Where(x => x.AllowedToMove)
                    .Where(x => !_board.Units.Select(u => u.Coordinates).Contains(x.Coordinates))
                    .Where(x => PathFinder.CanReach(x, _board.Player.CurrentCell))
                    .Where(x => PathFinder.Distance(x, _board.Player.CurrentCell) > 2)
                    .ToList();
            var robotAi = RobotAIFactory.Create(_board, isSmart);
            var robots =
                possibleCells.OrderBy(x => _random.Next())
                    .Take(amount)
                    .Select(x => new Robot(_board, x.Coordinates, robotAi))
                    .ToList();

            _board.Units.AddRange(robots);
            return this;
        }

        public static implicit operator Board(BoardBuilder mb)
        {
            mb._board.Units.ForEach(u => mb._board.Player.AddObserver(u));
            return mb._board;
        }

        private bool EachUnitReachable()
        {
            var playerCell = _board.Player.CurrentCell;
            return _board.Units.All(x => PathFinder.CanReach(x.CurrentCell, playerCell));
        }

        private bool CanPlaceHole(Cell cell)
        {
            var allowedToMove = cell.AllowedToMove;
            var unitsOnSameCoords = !_board.Units.Select(u => u.Coordinates).Contains(cell.Coordinates);
            var cellsAroundPlayer =
                _board.Player.CurrentCell.CellsAround.Where(x => x.Coordinates != cell.Coordinates)
                    .Any(c => c.AllowedToMove);
            var playerOnSameCoords = _board.Player.Coordinates != cell.Coordinates;
            return allowedToMove && unitsOnSameCoords && cellsAroundPlayer && playerOnSameCoords;
        }
    }
}