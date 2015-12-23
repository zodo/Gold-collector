namespace FirstStep.Commands
{
    using Actors;

    public class EmptyCommand : Command
    {
        public EmptyCommand()
            : base(null)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        public override bool Execute()
        {
            return false;
        }
    }
}