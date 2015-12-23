namespace FirstStep.Domain.AI
{
    using Board;

    using Commands;

    using Units;

    /// <summary>
    /// Искусственный интеллект робота.
    /// </summary>
    public abstract class RobotAI : GameObject
    {
        /// <summary>
        /// Поле.
        /// </summary>
        protected readonly Board Board;

        public RobotAI(Board board)
        {
            Board = board;
        }
        /// <summary>
        /// Получить инструкцию.
        /// </summary>
        public abstract Command NextTurn(Robot robot);
    }
}