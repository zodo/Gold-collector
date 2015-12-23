namespace FirstStep.Commands
{
    using Domain.Units;

    /// <summary>
    /// Комманда пойти влево.
    /// </summary>
    public class GoLeftCommand : Command
    {
        public GoLeftCommand(ActiveUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public override bool Execute()
        {
            return Unit.GoLeft();
        }
    }
}