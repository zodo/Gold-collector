namespace FirstStep.Commands
{
    using Domain.Units;

    /// <summary>
    /// Команда пойти вверх.
    /// </summary>
    public class GoUpCommand : Command
    {
        public GoUpCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public override bool Execute()
        {
            return Unit.GoUp();
        }
    }
}