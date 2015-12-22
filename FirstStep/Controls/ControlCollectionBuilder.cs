namespace FirstStep.Buttons
{
    using System;

    using Base;

    using Controls;

    using Game;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Строитель набора элементов управления.
    /// </summary>
    public class ControlCollectionBuilder : SimpleGameObject
    {
        /// <summary>
        /// Набор элементов управления.
        /// </summary>
        private readonly ContolCollection _contol;


        public ControlCollectionBuilder(ContolCollection contolCollection)
        {
            _contol = contolCollection;
        }

        /// <summary>
        /// Добавить элемент управления в набор.
        /// </summary>
        /// <param name="control">Элемент управления.</param>
        public ControlCollectionBuilder AddControl(Control control)
        {
            _contol.Contols.Add(control);
            return this;
        }

        /// <summary>
        /// Выводить набор по координатам.
        /// </summary>
        /// <param name="coords">Координаты центра.</param>
        public ControlCollectionBuilder AtCoords(Vector2 coords)
        {
            _contol.Coordinates = coords;
            return this;
        }

        public ControlCollectionBuilder AtCoords(ControlPosition position)
        {
            var coords = new Vector2();
            var screenSize = new Vector2(Game.Graphics.PreferredBackBufferWidth, Game.Graphics.PreferredBackBufferHeight);
            if (position.HasFlag(ControlPosition.Center))
            {
                coords = screenSize / 2;
            }
            if (position.HasFlag(ControlPosition.Top))
            {
                coords.Y = 0;
            }
            if (position.HasFlag(ControlPosition.Bottom))
            {
                coords.Y = screenSize.Y;
            }
            return AtCoords(coords);
        }

        /// <summary>
        /// Задать экранный размер набора.
        /// </summary>
        /// <param name="size">Размер на экране</param>
        public ControlCollectionBuilder SetSize(double size)
        {
            _contol.Size = size;
            return this;
        }

        /// <summary>
        /// Выполнить функцию перед обновлением.
        /// </summary>
        /// <param name="action">Функция.</param>
        public ControlCollectionBuilder BeforeUpdate(Action action)
        {
            _contol.OnUpdate = action;
            return this;
        }

        /// <summary>
        /// Задать цвет фона.
        /// </summary>
        /// <param name="color">Цвет.</param>
        public ControlCollectionBuilder WithBackground(Color color)
        {
            _contol.BackgroundColor = color;
            return this;
        }

        /// <summary>
        /// Задать цвет переднего плана.
        /// </summary>
        /// <param name="color">Цвет.</param>
        public ControlCollectionBuilder WithForeground(Color color)
        {
            _contol.ForegroundColor = color;
            return this;
        }

        /// <summary>
        /// Невное приведение строителя к набору контролов.
        /// </summary>
        public static implicit operator ContolCollection(ControlCollectionBuilder bcb)
        {
            return bcb._contol;
        }
    }
}
