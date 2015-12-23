namespace FirstStep.Commands
{
    using Actors;

    public class GoDownCommand : Command
    {
        public GoDownCommand(MoveableUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public override bool Execute()
        {
            return Unit.GoDown();
        }
    }
}