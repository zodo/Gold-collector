namespace FirstStep.Observer
{
    using Units;

    /// <summary>
    /// Наблюдатель.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        void OnNotify(MainGame.GameObject obj, EventType eventType);
    }
}
