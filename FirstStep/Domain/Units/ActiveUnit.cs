namespace FirstStep.Domain.Units
{
    using Board;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Юнит, способный выполнять действия.
    /// </summary>
    public abstract class ActiveUnit : Unit
    {
        private readonly Vector2 _down = new Vector2(0, 1);

        private readonly Vector2 _left = new Vector2(-1, 0);

        private readonly Vector2 _right = new Vector2(1, 0);

        private readonly Vector2 _up = new Vector2(0, -1);

        public ActiveUnit(Board board, Vector2 coords)
            : base(board, coords)
        {
        }

        /// <summary>
        /// Пойти влево.
        /// </summary>
        public bool GoLeft()
        {
            if (Board.CanGoTo(Coordinates + _left))
            {
                Coordinates += _left;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Пойти вправо.
        /// </summary>
        public bool GoRight()
        {
            if (Board.CanGoTo(Coordinates + _right))
            {
                Coordinates += _right;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Пойти вверх.
        /// </summary>
        /// <returns></returns>
        public bool GoUp()
        {
            if (Board.CanGoTo(Coordinates + _up))
            {
                Coordinates += _up;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Пойти вниз.
        /// </summary>
        /// <returns></returns>
        public bool GoDown()
        {
            if (Board.CanGoTo(Coordinates + _down))
            {
                Coordinates += _down;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Выполнить какое-либо действие.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public abstract bool Act();
    }
}