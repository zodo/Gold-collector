namespace FirstStep.Observer
{
    using Game;

    /// <summary>
    /// Наблюдатель.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        void OnNotify(GameObject obj, GameEvent gameEvent);
    }
}