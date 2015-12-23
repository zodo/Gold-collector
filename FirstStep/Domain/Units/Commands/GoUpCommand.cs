namespace FirstStep.Commands
{
    using Actors;

    public class GoUpCommand : Command
    {
        public GoUpCommand(MoveableUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public override bool Execute()
        {
            return Unit.GoUp();
        }
    }
}