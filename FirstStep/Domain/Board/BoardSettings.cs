namespace FirstStep.Board
{
    /// <summary>
    /// Настройки игры.
    /// </summary>
    public class BoardSettings
    {
        /// <summary>
        /// Ширина поля.
        /// </summary>
        public int BoardWidth { get; set; } = 10;

        /// <summary>
        /// Высота поля.
        /// </summary>
        public int BoardHeight { get; set; } = 10;

        /// <summary>
        /// Количество генерируемых роботов.
        /// </summary>
        public int RobotsAmount { get; set; } = 5;

        /// <summary>
        /// Количество генерируемого золота.
        /// </summary>
        public int GoldAmount { get; set; } = 6;

        /// <summary>
        /// Количество генерируемых отверстий.
        /// </summary>
        public int HolesAmount { get; set; } = 15;

        public bool SmartRobots { get; set; } = true;

        public int Seed { get; set; } = -1;

        public BoardSettings Clone()
        {
            return new BoardSettings
            {
                BoardHeight = BoardHeight,
                BoardWidth = BoardWidth,
                RobotsAmount = RobotsAmount,
                GoldAmount = GoldAmount,
                HolesAmount = HolesAmount,
                SmartRobots = SmartRobots
            };
        }
    }
}