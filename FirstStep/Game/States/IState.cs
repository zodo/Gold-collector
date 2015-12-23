namespace FirstStep.Game.States
{
    /// <summary>
    /// Состояние игры.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        IState Update();

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        void Draw();
    }
}