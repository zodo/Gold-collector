namespace FirstStep.Domain.Board
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using Units;

    /// <summary>
    /// Игровое поле.
    /// </summary>
    public class Board : InteractiveGameObject, IEnumerable<Cell>
    {
        /// <summary>
        /// Клетки поля.
        /// </summary>
        private Dictionary<int, Cell> Data { get; } = new Dictionary<int, Cell>();
        
        /// <summary>
        /// Список юнитов.
        /// </summary>
        public List<Unit> Units { get; } = new List<Unit>();

        /// <summary>
        /// Игрок.
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Временный буфер для отрисовки.
        /// </summary>
        private RenderTarget2D Buffer { get; }

        /// <summary>
        /// Получить клетку по координатам.
        /// </summary>
        /// <param name="coords">Кооридинаты.</param>
        public Cell this[Vector2 coords]
        {
            get { return Data[(int)(coords.X * 1000 + coords.Y)]; }
            set
            {
                if (!IsOnMap(coords))
                    throw new ArgumentOutOfRangeException("Coords out of range");
                
                var key = (int)(coords.X * 1000 + coords.Y);
                if (Data.Keys.Contains(key))
                {
                    Data[key] = value;
                }
                else
                {
                    Data.Add(key, value);
                }
            }
        }

        /// <summary>
        /// Координаты соответствуют клеткам поля.
        /// </summary>
        public bool IsOnMap(Vector2 coords) => coords.X >= 0 && coords.X < Width && coords.Y >= 0 && coords.Y < Height;

        /// <summary>
        /// Можно ли переместится по координатам.
        /// </summary>
        public bool CanGoTo(Vector2 coords) => IsOnMap(coords) && this[coords].IsGround;

        /// <summary>
        /// Высота.
        /// </summary>
        private int Height { get; }

        /// <summary>
        /// Ширина.
        /// </summary>
        private int Width { get; }

        /// <summary>
        /// Создать экземпляр <see cref="Board"/>
        /// </summary>
        private Board(int width, int height)
        {
            Width = width;
            Height = height;
            FillDataWithGround();
            Player = new Player(this, new Vector2(Width / 2, Height / 2));

            Buffer = new RenderTarget2D(
                Game.GraphicsDevice,
                width * Settings.CellSizeInPixels,
                height * Settings.CellSizeInPixels,
                false,
                Game.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24);
        }
        
        /// <summary>
        /// Создать <see cref="Board"/>
        /// </summary>
        /// <param name="width">Ширина.</param>
        /// <param name="height">Высота.</param>
        /// <param name="seed">Номер карты.</param>
        /// <returns></returns>
        public static BoardBuilder Create(int width, int height, int seed = -1)
        {
            return new BoardBuilder(new Board(width, height), seed);
        }

        /// <summary>
        /// Заполнить поле землей.
        /// </summary>
        private void FillDataWithGround()
        {
            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    this[new Vector2(x, y)] = new Cell(this, new Vector2(x, y), true);
                }
            }
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
            Player.Update();
            Units.ForEach(u => u.Update());
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

            Game.SpriteBatch.Draw(Buffer, GetMapSize(), Color.White);
        }
        
        public IEnumerator<Cell> GetEnumerator()
        {
            return Data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Получить размер и координаты карты на экране.
        /// </summary>
        /// <returns></returns>
        private Rectangle GetMapSize()
        {
            var oldW = Width * Settings.CellSizeInPixels;
            var oldH = Height * Settings.CellSizeInPixels;
            var oldP = (double)oldW / oldH;
            var newW = Game.Graphics.PreferredBackBufferWidth;
            var newH = Game.Graphics.PreferredBackBufferHeight;
            var newP = (double)newW / newH;

            if (oldW < newW && oldH < newH)
            {
                return new Rectangle(newW / 2 - oldW / 2, newH / 2 - oldH / 2, oldW, oldH);
            }
            double f;
            if (newP > oldP)
            {
                f = (double)newH / oldH;
            }
            else
            {
                f = (double)newW / oldW;
            }
            oldW = (int)(oldW * f);
            oldH = (int)(oldH * f);
            return new Rectangle(newW / 2 - oldW / 2, newH / 2 - oldH / 2, oldW, oldH);
        }
    }
}