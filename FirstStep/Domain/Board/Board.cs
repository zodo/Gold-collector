namespace FirstStep.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Observer;

    using Units;

    public class Board : InteractiveGameObject, IEnumerable<Cell>
    {
        private readonly Dictionary<int, Cell> _data = new Dictionary<int, Cell>();

        public int Height { get; }

        public int Width { get; }

        private Board(int width, int height)
        {
            Width = width;
            Height = height;
            FillDataWithGround(width, height);
            Buffer = new RenderTarget2D(
                Game.GraphicsDevice,
                width * 50,
                height * 50,
                false,
                Game.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }

        public List<Unit> Units { get; } = new List<Unit>();

        public Player Player { get; set; }

        public RenderTarget2D Buffer { get; }

        public Cell this[Vector2 coords]
        {
            get
            {
                var key = (int)(coords.X * 1000 + coords.Y);
                return _data[key];
            }
            set
            {
                if (!IsOnMap(coords))
                {
                    throw new ArgumentOutOfRangeException("Coords out of range");
                }
                var key = (int)(coords.X * 1000 + coords.Y);
                if (_data.Keys.Contains(key))
                {
                    _data[key] = value;
                }
                else
                {
                    _data.Add(key, value);
                }
            }
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1" />, который может использоваться для перебора
        /// элементов коллекции.
        /// </returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }

        /// <summary>
        /// Возвращает перечислитель, который осуществляет перебор элементов коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator" />, который может использоваться для перебора элементов коллекции.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsOnMap(Vector2 coords) => coords.X >= 0 && coords.X < Width && coords.Y >= 0 && coords.Y < Height;

        public bool CanGoTo(Vector2 coords) => IsOnMap(coords) && this[coords].AllowedToMove;

        public static BoardBuilder Create(int width, int height, int seed = -1)
        {
            return new BoardBuilder(new Board(width, height), seed);
        }

        private void FillDataWithGround(int width, int height)
        {
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    this[new Vector2(x,y)] = new Cell(this, new Vector2(x, y), true);
                }
            }
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
            Player.Update();
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            using (new DrawToBuffer(Buffer))
            {
                foreach (var cell in this)
                {
                    cell.Draw();
                }
                foreach (var unit in Units)
                {
                    unit.Draw();
                }
                Player.Draw();
            }
            Game.SpriteBatch.Draw(
                Buffer,
                new Rectangle(0, 0, Game.Graphics.PreferredBackBufferWidth, Game.Graphics.PreferredBackBufferHeight),
                Color.White);
        }

        public void DrawHud()
        {
            
        }

        
    }
}