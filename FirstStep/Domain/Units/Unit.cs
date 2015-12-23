namespace FirstStep.Units
{
    using Board;

    using Game;

    using Microsoft.Xna.Framework;

    using Observer;

    public abstract class Unit : InteractiveGameObject, IObserver
    {
        public Unit(Board board, Vector2 coords)
        {
            Board = board;
            Coordinates = coords;
        }

        public Vector2 Coordinates { get; set; }

        public Board Board { get; }

        public Cell CurrentCell => Board[Coordinates];

        /// <summary>
        /// При изменении.
        /// </summary>
        /// <param name="obj">Юнит.</param>
        /// <param name="eventType">Событие.</param>
        public abstract void OnNotify(SimpleGameObject obj, EventType eventType);
    }
}