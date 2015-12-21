namespace FirstStep.Commands
{
    using Actors;

    /// <summary>
    /// Комманда пойти влево.
    /// </summary>
    public class GoLeftCommand : ICommand
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <param name="moveableUnit">Игрок.</param>
        public void Execute(MoveableUnit moveableUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}
