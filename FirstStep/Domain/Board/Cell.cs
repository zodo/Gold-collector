namespace FirstStep.Board
{
    using System.Collections.Generic;
    using System.Linq;

    using Game;

    using Microsoft.Xna.Framework;

    public class Cell : InteractiveGameObject
    {
        private readonly Vector2[] _directions =
        {
            new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0)
        };

        public Cell(Board board, Vector2 coordinates, bool allowedToMove)
        {
            Board = board;
            Coordinates = coordinates;
            AllowedToMove = allowedToMove;
        }

        public Board Board { get; set; }

        public Vector2 Coordinates { get; set; }

        public bool AllowedToMove { get; }

        public double FullDistance { get; set; }

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
            var color = AllowedToMove ? Color.DarkGray : Color.Black;
            Game.SpriteBatch.Draw(
                Game.WhiteRectangle,
                new Rectangle((int)(Coordinates.X * 50) + 5, (int)(Coordinates.Y * 50) + 5, 40, 40),
                color);
        }
    }
}