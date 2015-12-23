namespace FirstStep.Actors
{
    using Board;

    using Microsoft.Xna.Framework;

    using Units;

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


        public bool GoLeft()
        {
            if (Board.CanGoTo(Coordinates + _left))
            {
                Coordinates += _left;
                return true;
            }
            return false;
        }

        public bool GoRight()
        {
            if (Board.CanGoTo(Coordinates + _right))
            {
                Coordinates += _right;
                return true;
            }
            return false;
        }

        public bool GoUp()
        {
            if (Board.CanGoTo(Coordinates + _up))
            {
                Coordinates += _up;
                return true;
            }
            return false;
        }

        public bool GoDown()
        {
            if (Board.CanGoTo(Coordinates + _down))
            {
                Coordinates += _down;
                return true;
            }
            return false;
        }

        public abstract bool Act();
    }
}