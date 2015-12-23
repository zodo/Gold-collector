namespace FirstStep.Domain.Board
{
    using System;
    using System.Linq;

    using AI;
    using PathFinding;
    using Units;

    /// <summary>
    /// Строитель игрового поля.
    /// </summary>
    public class BoardBuilder
    {
        /// <summary>
        /// Игровое поле.
        /// </summary>
        private readonly Board _board;

        private readonly Random _random;

        public BoardBuilder(Board board, int seed = -1)
        {
            _board = board;
            _random = seed >= 0 ? new Random(seed) : new Random();
        }

        /// <summary>
        /// Добавить отверстий.
        /// </summary>
        /// <param name="amount">Количество.</param>
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

        /// <summary>
        /// Добавить золото.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public BoardBuilder AddGold(int amount)
        {
            var possibleCells =
                _board.Where(x => x.IsHole)
                    .Where(x => !_board.Units.Select(u => u.Coordinates).Contains(x.Coordinates))
                    .Where(x => _board.Player.Coordinates != x.Coordinates)
                    .Where(x => PathFinder.CanReach(x, _board.Player.CurrentCell));
            var gold =
                possibleCells.OrderBy(x => _random.Next())
                    .Take(amount)
                    .Select(x => new Gold(_board, x.Coordinates));
            _board.Units.AddRange(gold);
            return this;
        }


        /// <summary>
        /// Добавить роботов.
        /// </summary>
        /// <param name="amount">Количество.</param>
        /// <param name="isSmart">Умны?</param>
        /// <returns></returns>
        public BoardBuilder AddRobots(int amount, bool isSmart = true)
        {
            var possibleCells =
                _board.Where(x => x.IsHole)
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

        /// <summary>
        /// Неявное привидение строителя к игровому полю.
        /// </summary>
        /// <param name="mb"></param>
        public static implicit operator Board(BoardBuilder mb)
        {
            mb._board.Units.ForEach(u => mb._board.Player.AddObserver(u));
            return mb._board;
        }

        /// <summary>
        /// Можно ли разместить отверстие.
        /// </summary>
        private bool CanPlaceHole(Cell cell)
        {
            var allowedToMove = cell.IsHole;
            var unitsOnSameCoords = !_board.Units.Select(u => u.Coordinates).Contains(cell.Coordinates);
            var cellsAroundPlayer =
                _board.Player.CurrentCell.CellsAround.Where(x => x.Coordinates != cell.Coordinates)
                    .Any(c => c.IsHole);
            var playerOnSameCoords = _board.Player.Coordinates != cell.Coordinates;
            return allowedToMove && unitsOnSameCoords && cellsAroundPlayer && playerOnSameCoords;
        }
    }
}