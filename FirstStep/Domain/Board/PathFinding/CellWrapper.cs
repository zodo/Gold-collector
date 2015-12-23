namespace FirstStep.Domain.Board.PathFinding
{
    using FirstStep.Board;

    /// <summary>
    /// Обертка для <see cref="Cell"/> для реализации A*
    /// </summary>
    public class CellWrapper
    {
        public CellWrapper(Cell cell)
        {
            Cell = cell;
        }

        /// <summary>
        /// Клетка поля.
        /// </summary>
        public Cell Cell { get; set; }

        /// <summary>
        /// Расстояние до цели.
        /// </summary>
        public double DistToEnd { get; set; }

        /// <summary>
        /// Расстояние от начала до цели.
        /// </summary>
        public double FullDistance => DistFromStart + DistToEnd;

        /// <summary>
        /// Предыдущая клетка пути.
        /// </summary>
        public CellWrapper Previous { get; set; }

        /// <summary>
        /// Расстояние от старта.
        /// </summary>
        public double DistFromStart { get; set; }

        /// <summary>
        /// Является ли клетка стартом?
        /// </summary>
        public bool IsStart { get; set; }
    }
}