namespace FirstStep.Game.States
{
    /// <summary>
    /// Базовый класс состояния.
    /// </summary>
    public abstract class State : GameObject
    {
        protected State NewState { get; set; }

        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        public State Update()
        {
            DoUpdate();
            return NewState;
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Выполнить обновление.
        /// </summary>
        protected abstract void DoUpdate();
    }
}
