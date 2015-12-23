namespace FirstStep.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Game;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Набор элементов управления.
    /// </summary>
    public class ContolCollection : InteractiveGameObject
    {
        /// <summary>
        /// Базовый размер контрола.
        /// </summary>
        private const int BaseSize = 50;

        /// <summary>
        /// Элементы управления.
        /// </summary>
        public readonly List<Control> Contols = new List<Control>();

        /// <summary>
        /// Индекс выбранного элемента.
        /// </summary>
        private int _selectedIndex;

        /// <summary>
        /// Обработчик обновления значения.
        /// </summary>
        public Action OnUpdate = () => { };

        /// <summary>
        /// Цвет фона.
        /// </summary>
        public Color BackgroundColor { get; set; } = Color.BurlyWood;

        /// <summary>
        /// Цвет переднего плана.
        /// </summary>
        public Color ForegroundColor { get; set; } = Color.Brown;

        /// <summary>
        /// Координаты.
        /// </summary>
        public Vector2 Coordinates { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public double Size { get; set; } = 5;

        public List<Label> Labels { get; set; } = new List<Label>();

        /// <summary>
        /// Создать набор.
        /// </summary>
        /// <returns></returns>
        public static ControlCollectionBuilder Create()
        {
            return new ControlCollectionBuilder(new ContolCollection());
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
            OnUpdate();
            var firstTime = GetKeysWithoutRepitions();
            if (firstTime.Contains(Keys.Down))
            {
                Down();
            }
            if (firstTime.Contains(Keys.Up))
            {
                Up();
            }
            Contols[_selectedIndex].OnKeysPressed(firstTime);
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            var width = (int)(Size * BaseSize);
            var height = (int)(Contols.Count * Size * BaseSize / 5 + Labels.Sum(l => l.Size * Size * BaseSize / 10));
            var x = (int)(Coordinates.X - width / 2);
            var y = (int)(Coordinates.Y - height / 2);

            Game.SpriteBatch.Draw(Game.WhiteRectangle, new Rectangle(x, y, width, height), BackgroundColor);

            if (Labels.Any())
            {
                var lbl = Labels.First();
                var lblW = (int)(Size * BaseSize * lbl.Size / 2);
                var lblH = (int)(Size * BaseSize / 10 * lbl.Size);
                var lblx = (int)(Coordinates.X - lblW / 2);
                var lbly = (int)(y);
                DrawString(lbl.Caption, new Rectangle(lblx, lbly, lblW, lblH), ForegroundColor);
                for (int index = 1; index < Labels.Count; index++)
                {
                    lbl = Labels[index];
                    lbly += lblH;
                    lblW = (int)(Size * BaseSize * lbl.Size / 2);
                    lblH = (int)(Size * BaseSize / 10 * lbl.Size);
                    lblx = (int)(Coordinates.X - lblW / 2);
                    DrawString(lbl.Caption, new Rectangle(lblx, lbly, lblW, lblH), ForegroundColor);

                }
            }
           

            y += (int)Labels.Sum(l => l.Size * Size * BaseSize / 10);

            for (var i = 0; i < Contols.Count; i++)
            {
                var ctrlX = (int)(x + Size);
                var ctrlY = (int)(y + i * Size * BaseSize / 5 + Size);
                var ctrlH = (int)(Size * BaseSize / 5 - Size * 2);
                var ctrlW = (int)(width - Size * 2);

                Contols[i].DrawAt(new Rectangle(ctrlX, ctrlY, ctrlW, ctrlH), ForegroundColor);

                if (i == _selectedIndex)
                {
                    Game.SpriteBatch.Draw(
                        Game.WhiteRectangle,
                        new Rectangle((int)(ctrlX + BaseSize * Size / 4), (int)(ctrlY + ctrlH - Size), (int)(ctrlW - BaseSize * Size / 2), (int)Size),
                        ForegroundColor);
                }
            }
        }

        /// <summary>
        /// Выделить следующий контрол в наборе.
        /// </summary>
        private void Down()
        {
            _selectedIndex++;
            //if (!Contols[_selectedIndex].CanSelect)
            //{
            //    _selectedIndex = Contols.Select((x, i) => new { x, i }).Skip(_selectedIndex).FirstOrDefault(x => x.x.CanSelect)?.i ?? _selectedIndex;
            //}
            if (_selectedIndex >= Contols.Count)
            {
                _selectedIndex = 0;
               // _selectedIndex = Contols.Select((x, i) => new { x, i }).Skip(_selectedIndex).FirstOrDefault(x => x.x.CanSelect)?.i ?? _selectedIndex;
            }
        }

        /// <summary>
        /// Выделить предыдущий контрол в наборе.
        /// </summary>
        private void Up()
        {
            _selectedIndex--;
            if (_selectedIndex < 0)
            {
                _selectedIndex = Contols.Count - 1;
            }
        }
    }
}