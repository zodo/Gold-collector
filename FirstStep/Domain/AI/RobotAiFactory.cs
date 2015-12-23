namespace FirstStep.Domain.AI
{
    using FirstStep.Board;

    public static class RobotAIFactory
    {
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