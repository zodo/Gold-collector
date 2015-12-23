﻿namespace FirstStep.Game
{
    /// <summary>
    /// Настройки игры.
    /// </summary>
    public class GameSettings
    {
        /// <summary>
        /// Ширина поля.
        /// </summary>
        public int BoardWidth { get; set; } = 10;

        /// <summary>
        /// Высота поля.
        /// </summary>
        public int BoardHeight { get; set; } = 10;

        /// <summary>
        /// Количество генерируемых роботов.
        /// </summary>
        public int RobotsAmount { get; set; } = 5;

        /// <summary>
        /// Количество генерируемого золота.
        /// </summary>
        public int GoldAmount { get; set; } = 6;

        /// <summary>
        /// Количество генерируемых отверстий.
        /// </summary>
        public int HolesAmount { get; set; } = 15;

        /// <summary>
        /// Роботы с поиском пути.
        /// </summary>
        public bool SmartRobots { get; set; } = true;

        /// <summary>
        /// Номер карты.
        /// </summary>
        public int Seed { get; set; } = -1;

        /// <summary>
        /// Кол-во зарядов оружия.
        /// </summary>
        public int Charges { get; set; } = 3;

        /// <summary>
        /// Клонировать настройки.
        /// </summary>
        /// <returns></returns>
        public GameSettings Clone()
        {
            return new GameSettings
            {
                BoardHeight = BoardHeight,
                BoardWidth = BoardWidth,
                RobotsAmount = RobotsAmount,
                GoldAmount = GoldAmount,
                HolesAmount = HolesAmount,
                SmartRobots = SmartRobots,
                Seed = Seed,
                Charges = Charges
            };
        }
    }
}