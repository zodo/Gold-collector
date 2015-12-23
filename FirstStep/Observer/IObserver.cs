namespace FirstStep.Observer
{
    using Game;

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
        void OnNotify(SimpleGameObject obj, EventType eventType);
    }
}