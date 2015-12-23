namespace FirstStep.Commands
{
    using Actors;

    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    public abstract class Command
    {
        protected readonly ActiveUnit Unit;

        protected Command(ActiveUnit unit)
        {
            Unit = unit;
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public abstract bool Execute();
    }
}