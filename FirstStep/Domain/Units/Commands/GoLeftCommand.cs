namespace FirstStep.Commands
{
    using Actors;

    /// <summary>
    /// Комманда пойти влево.
    /// </summary>
    public class GoLeftCommand : Command
    {
        public GoLeftCommand(MoveableUnit unit)
            : base(unit)
        {
        }

        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <param name="moveableUnit">Игрок.</param>
        public override bool Execute()
        {
            return Unit.GoLeft();
        }
    }
}