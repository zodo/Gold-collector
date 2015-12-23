﻿namespace FirstStep.Commands
{
    using Actors;

    public class GoRightCommand : Command
    {
        public GoRightCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public override bool Execute()
        {
            return Unit.GoRight();
        }
    }
}