namespace FirstStep.Commands
{
    using System;
    using System.Linq;

    using Actors;

    using Board;

    using Domain.Units.Commands;

    using Microsoft.Xna.Framework.Input;

    public static class CommandFactory
    {
        public static Command Create(ActiveUnit unit, Keys[] pressed)
        {
            if (pressed.Contains(Keys.Left))
            {
                return new GoLeftCommand(unit);
            }
            if (pressed.Contains(Keys.Right))
            {
                return new GoRightCommand(unit);
            }
            if (pressed.Contains(Keys.Up))
            {
                return new GoUpCommand(unit);
            }
            if (pressed.Contains(Keys.Down))
            {
                return new GoDownCommand(unit);
            }
            if (pressed.Contains(Keys.Space))
            {
                return new ActCommand(unit);
            }
            return new EmptyCommand();
        }

        public static Command Create(ActiveUnit unit, Cell next)
        {
            if (next == null)
            {
                return new EmptyCommand();
            }
            var diff = unit.CurrentCell.Coordinates - next.Coordinates;
            if (Math.Abs(diff.X + 1) < 0.1)
            {
                return new GoRightCommand(unit);
            }
            if (Math.Abs(diff.X - 1) < 0.1)
            {
                return new GoLeftCommand(unit);
            }
            if (Math.Abs(diff.Y - 1) < 0.1)
            {
                return new GoUpCommand(unit);
            }
            if (Math.Abs(diff.Y + 1) < 0.1)
            {
                return new GoDownCommand(unit);
            }
            return new EmptyCommand();
        }
    }
}