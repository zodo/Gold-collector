namespace FirstStep.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Buttons;

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
        /// Индекс выбранного элемента.
        /// </summary>
        private int _selectedIndex;

        /// <summary>
        /// Клавиши, нажатые на предыдущем цикле.
        /// </summary>
        private Keys[] _previouslyPressed;

        /// <summary>
        /// Обработчик обновления значения.
        /// </summary>
        public Action OnUpdate = () => { };

        /// <summary>
        /// Элементы управления.
        /// </summary>
        public readonly List<Control> Contols = new List<Control>();

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
        public double Size { get; set; }

        private ContolCollection()
        {
            _previouslyPressed = Keyboard.GetState().GetPressedKeys();
        }
        
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

            var keysPressed = Keyboard.GetState().GetPressedKeys();
            var firstTime = keysPressed.Except(_previouslyPressed).ToArray();
            if (firstTime.Contains(Keys.Down))
            {
                Down();
            }
            if (firstTime.Contains(Keys.Up))
            {
                Up();
            }
            Contols[_selectedIndex].OnKeysPressed(firstTime);

            _previouslyPressed = keysPressed;
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            var width = (int)(Size * BaseSize);
            var height = (int)(Contols.Count * Size * BaseSize / 5);
            var x = (int)(Coordinates.X - width / 2);
            var y = (int)(Coordinates.Y - height / 2);

            Game.SpriteBatch.Draw(Game.WhiteRectangle, new Rectangle(x, y, width, height), BackgroundColor);

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
                        new Rectangle(ctrlX, (int)(ctrlY + ctrlH - Size), ctrlW, (int)Size),
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
            if (_selectedIndex >= Contols.Count)
            {
                _selectedIndex = 0;
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