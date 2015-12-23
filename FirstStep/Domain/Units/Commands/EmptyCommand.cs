namespace FirstStep.Commands
{
    /// <summary>
    /// Пустая команда.
    /// </summary>
    public class EmptyCommand : Command
    {
        public EmptyCommand()
            : base(null)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <returns>Успешность выполнения.</returns>
        public override bool Execute()
        {
            return false;
        }
    }
}