namespace FirstStep.Domain.Board.PathFinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FirstStep.Board;

    /// <summary>
    /// Калькулятор оптимального пути.
    /// </summary>
    public static class PathFinder
    {
        private static HashSet<CellWrapper> _wrappers;

        private static Random _random = new Random(0);

        /// <summary>
        /// Получить путь.
        /// </summary>
        /// <param name="start">Стартовая клетка.</param>
        /// <param name="end">Конечная клетка.</param>
        /// <returns></returns>
        public static Path GetPath(Cell start, Cell end, bool walkOnUnits = true)
        {
            _wrappers = new HashSet<CellWrapper>();
            var startWrapper = CreateWrapper(start);
            startWrapper.IsStart = true;
            var endWrapper = CreateWrapper(end);
            var closed = new List<CellWrapper>();
            var opened = new List<CellWrapper> { startWrapper };
            startWrapper.DistToEnd = Distance(startWrapper, endWrapper);

            while (opened.Any())
            {
                if (opened.Select(x => x.Cell.Coordinates).Contains(endWrapper.Cell.Coordinates))
                {
                    return new Path(endWrapper);
                }
                var optimal = opened.GroupBy(x => x.FullDistance).OrderBy(c => c.Key).First().OrderBy(x => _random.Next()).First();
                opened.Remove(optimal);
                closed.Add(optimal);
                var neighbours =
                    optimal.Cell.CellsAround.Where(neighbour => neighbour.AllowedToMove)
                        .Where(neighbour => !closed.Select(x => x.Cell).Contains(neighbour))
                        .Where(x => walkOnUnits || !start.Board.Units.Select(u => u.Coordinates).Contains(x.Coordinates))
                        .Select(CreateWrapper)
                        .ToList();
                foreach (var neighbour in neighbours)
                {
                    if (!opened.Contains(neighbour))
                    {
                        opened.Add(neighbour);
                        neighbour.Previous = optimal;
                        neighbour.DistFromStart = optimal.DistFromStart + Distance(optimal, neighbour);
                        neighbour.DistToEnd = Distance(neighbour, endWrapper);
                    }
                    else if (optimal.DistFromStart + Distance(optimal, neighbour) < neighbour.DistFromStart)
                    {
                        neighbour.Previous = optimal;
                        neighbour.DistFromStart = optimal.DistFromStart + Distance(optimal, neighbour);
                        neighbour.DistToEnd = Distance(neighbour, endWrapper);
                    }
                }
            }
            return new Path();
        }

        private static CellWrapper CreateWrapper(Cell cell)
        {
            var wrapper = _wrappers.SingleOrDefault(x => x.Cell == cell);
            if (wrapper != null)
            {
                return wrapper;
            }
            wrapper = new CellWrapper(cell) { IsStart = false };
            _wrappers.Add(wrapper);
            return wrapper;
        }

        public static bool CanReach(Cell one, Cell two)
        {
            return GetPath(one, two).Any();
        }

        private static double Distance(CellWrapper start, CellWrapper end)
        {
            //return Math.Abs(start.Cell.Coordinates.X - end.Cell.Coordinates.X)
            //       + Math.Abs(start.Cell.Coordinates.Y - end.Cell.Coordinates.Y);
            return Math.Sqrt(Math.Pow(start.Cell.Coordinates.X - end.Cell.Coordinates.X, 2) + Math.Pow(start.Cell.Coordinates.Y - end.Cell.Coordinates.Y, 2));

        }

        public static double Distance(Cell from, Cell to)
        {
            return Distance(new CellWrapper(from), new CellWrapper(to));
        }
    }
}