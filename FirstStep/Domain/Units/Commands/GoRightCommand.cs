namespace FirstStep.Commands
{
    using Domain.Units;

    /// <summary>
    /// Команда пойти вправо.
    /// </summary>
    public class GoRightCommand : Command
    {
        public GoRightCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public override bool Execute()
        {
            return Unit.GoRight();
        }
    }
}