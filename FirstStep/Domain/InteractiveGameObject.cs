namespace FirstStep.Game
{
    using System.Linq;

    using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Интерактивный игровой объект.
    /// </summary>
    public abstract class InteractiveGameObject : SimpleGameObject
    {
        /// <summary>
        /// Клавиши, нажатые на предыдущем цикле.
        /// </summary>
        private Keys[] _previouslyPressed;

        protected InteractiveGameObject()
        {
            _previouslyPressed = Keyboard.GetState().GetPressedKeys();
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public abstract void Draw();

        public Keys[] GetKeysWithoutRepitions()
        {
            var keysPressed = Keyboard.GetState().GetPressedKeys();
            var firstTime = keysPressed.Except(_previouslyPressed).ToArray();
            _previouslyPressed = keysPressed;
            return firstTime;
        }
    }
}