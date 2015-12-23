namespace FirstStep.Observer
{
    using System.Collections.Generic;

    /// <summary>
    /// Наблюдаемый.
    /// </summary>
    public abstract class Subject
    {
        /// <summary>
        /// Подписчики на события.
        /// </summary>
        private readonly List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// Добавить наблюдателя.
        /// </summary>
        /// <param name="observer">Наблюдатель.</param>
        public void AddObserver(IObserver observer) => _observers.Add(observer);

        /// <summary>
        /// Удалить наблюдателя.
        /// </summary>
        /// <param name="observer">Наблюдатель.</param>
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        /// <summary>
        /// Уведомить подписчиков.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        protected void Notify(GameObject obj, GameEvent gameEvent)
            => _observers.ForEach(x => x.OnNotify(obj, gameEvent));
    }
}