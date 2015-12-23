namespace FirstStep.Domain.Board.PathFinding
{
    using FirstStep.Board;

    public class CellWrapper
    {
        public CellWrapper(Cell cell)
        {
            Cell = cell;
        }

        public Cell Cell { get; set; }

        public double DistToEnd { get; set; }

        public double FullDistance => DistFromStart + DistToEnd;

        public CellWrapper Previous { get; set; }

        public double DistFromStart { get; set; }

        public bool IsStart { get; set; }
    }
}