namespace FirstStep.Commands
{
    using Domain.Units;

    /// <summary>
    /// Команда пойти вниз.
    /// </summary>
    public class GoDownCommand : Command
    {
        public GoDownCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public override bool Execute()
        {
            return Unit.GoDown();
        }
    }
}