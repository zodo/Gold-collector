namespace FirstStep.Domain.AI
{
    using Board;

    /// <summary>
    /// Фабрика ии.
    /// </summary>
    public static class RobotAIFactory
    {
        /// <summary>
        /// Создать экземпляр <see cref="RobotAI"/>
        /// </summary>
        /// <param name="board">Поле.</param>
        /// <param name="smartAi">Умность.</param>
        /// <returns></returns>
        public static RobotAI Create(Board board, bool smartAi)
        {
            if (smartAi)
            {
                return new RobotSmartAI(board);
            }
            return new RobotDumbAI(board);
        }
    }
}