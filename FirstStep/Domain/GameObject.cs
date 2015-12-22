namespace FirstStep
{
    using System;

    using Domain;

    using Observer;

    public partial class MainGame
    {
        /// <summary>
        /// Базовый класс для всех игровых объектов.
        /// </summary>
        /// <remarks>Определяет точку доступа к основному объекту игры.</remarks>
        public abstract class GameObject : Subject
        {
            /// <summary>
            /// Игра.
            /// </summary>
            protected MainGame Game => _instance;

            /// <summary>
            /// Настройки.
            /// </summary>
            protected BoardSettings Settings
            {
                get
                {
                    return _settings;
                }
                set
                {
                    _settings = value;
                }
            }
        }
    }
    
}
