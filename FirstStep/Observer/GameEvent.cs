namespace FirstStep.Observer
{
    /// <summary>
    /// Событие.
    /// </summary>
    public enum GameEvent
    {
        /// <summary>
        /// Золото собрано.
        /// </summary>
        GoldTaken,

        /// <summary>
        /// Игрок шагнул.
        /// </summary>
        PlayerWalked,

        /// <summary>
        /// Игра окончена поражением.
        /// </summary>
        GameOver,

        /// <summary>
        /// Игра окончена победой.
        /// </summary>
        Victory,

        /// <summary>
        /// Игрок использовал оружие.
        /// </summary>
        WeaponUsed,

        /// <summary>
        /// Игрок коснулся робота.
        /// </summary>
        PlayerTouchRobot
    }
}