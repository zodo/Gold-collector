namespace FirstStep.Domain.Units.Commands
{
    using Actors;

    using FirstStep.Commands;

    public class ActCommand : Command
    {
        public ActCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public override bool Execute()
        {
            return Unit.Act();
        }
    }
}
