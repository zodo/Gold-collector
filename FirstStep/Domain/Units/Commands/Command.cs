namespace FirstStep.Commands
{
    using Domain.Units;

    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Юнит
        /// </summary>
        protected readonly ActiveUnit Unit;

        protected Command(ActiveUnit unit)
        {
            Unit = unit;
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public abstract bool Execute();
    }
}