namespace FirstStep.Commands
{
    using Actors;

    /// <summary>
    /// Базовый класс команды.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <param name="moveableUnit">Игрок.</param>
        void Execute(MoveableUnit moveableUnit);
    }
}
