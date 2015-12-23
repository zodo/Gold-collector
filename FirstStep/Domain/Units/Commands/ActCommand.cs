namespace FirstStep.Domain.Units.Commands
{
    using FirstStep.Commands;

    /// <summary>
    /// Команда выполнить действие.
    /// </summary>
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