namespace FirstStep.Domain.Units
{
    using Board;
    using Game;
    using Microsoft.Xna.Framework;
    using Observer;

    /// <summary>
    /// Юнит.
    /// </summary>
    public abstract class Unit : InteractiveGameObject, IObserver
    {
        protected Unit(Board board, Vector2 coords)
        {
            Board = board;
            Coordinates = coords;
        }

        /// <summary>
        /// Координаты.
        /// </summary>
        public Vector2 Coordinates { get; set; }

        /// <summary>
        /// Игровое поле.
        /// </summary>
        protected Board Board { get; }

        /// <summary>
        /// Клетка, на которой стоит юнит.
        /// </summary>
        public Cell CurrentCell => Board[Coordinates];

        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public abstract void OnNotify(GameObject obj, GameEvent gameEvent);
    }
}