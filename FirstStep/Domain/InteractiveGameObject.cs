namespace FirstStep.Game
{
    /// <summary>
    /// Интерактивный игровой объект.
    /// </summary>
    public abstract class InteractiveGameObject : SimpleGameObject
    {
        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public abstract void Draw();
    }
}
