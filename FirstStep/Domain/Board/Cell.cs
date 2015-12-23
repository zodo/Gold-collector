namespace FirstStep.Domain.Board
{
    using System.Collections.Generic;
    using System.Linq;

    using Game;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Клетка игрового поля.
    /// </summary>
    public class Cell : InteractiveGameObject
    {
        /// <summary>
        /// Направления до соседей.
        /// </summary>
        private readonly Vector2[] _directions =
        {
            new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1),
            new Vector2(-1, 0)
        };

        public Cell(Board board, Vector2 coordinates, bool isHole)
        {
            Board = board;
            Coordinates = coordinates;
            IsHole = isHole;
        }

        /// <summary>
        /// Игровое поле.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// Координаты.
        /// </summary>
        public Vector2 Coordinates { get; set; }

        /// <summary>
        /// Является отверстием.
        /// </summary>
        public bool IsHole { get; }

        /// <summary>
        /// Соседи.
        /// </summary>
        public IEnumerable<Cell> CellsAround
        {
            get
            {
                var cells =
                    _directions.Select(x => x + Coordinates).Where(x => Board.IsOnMap(x)).Select(x => Board[x]).ToList();
                return cells;
            }
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            var color = IsHole ? Color.DarkGray : Color.Black;
            var size = Settings.CellSizeInPixels;
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * size) + size / 10, (int)(Coordinates.Y * size) + size / 10, size - size / 5, size - size / 5),
                color);
        }
    }
}