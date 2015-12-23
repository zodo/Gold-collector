namespace FirstStep.Commands
{
    using Actors;

    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    public abstract class Command
    {
        protected readonly MoveableUnit Unit;

        protected Command(MoveableUnit unit)
        {
            Unit = unit;
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public abstract bool Execute();
    }
}