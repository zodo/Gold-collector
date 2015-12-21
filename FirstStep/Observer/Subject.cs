namespace FirstStep.Observer
{
    using System.Collections.Generic;

    using Units;

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
        /// <param name="observer"></param>
        public void AddObserver(IObserver observer) => _observers.Add(observer);

        /// <summary>
        /// Удалить наблюдателя.
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        /// <summary>
        /// Уведомить подписчиков.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        protected void Notify(GoldGame.GameObject obj, EventType eventType) => _observers.ForEach(x => x.OnNotify(obj, eventType));
    }
}
