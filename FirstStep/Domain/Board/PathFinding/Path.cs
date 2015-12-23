namespace FirstStep.Domain.Board.PathFinding
{
    using System.Collections;
    using System.Collections.Generic;

    using FirstStep.Board;

    /// <summary>
    /// Найденный путь.
    /// </summary>
    public class Path : IEnumerable<Cell>
    {
        /// <summary>
        /// Список клеток в пути.
        /// </summary>
        private readonly List<Cell> _cells = new List<Cell>();

        /// <summary>
        /// Конструктор <see cref="Path" />
        /// </summary>
        /// <param name="end">Конечная клетка пути.</param>
        public Path(CellWrapper end)
        {
            var current = end;
            while (!current.IsStart)
            {
                _cells.Add(current.Cell);
                current = current.Previous;
                if (current == null || _cells.Contains(current.Cell))
                {
                    return;
                }
            }
            _cells.Add(current.Cell);
        }

        /// <summary>
        /// Создать пустой путь.
        /// </summary>
        public Path()
        {
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return _cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}