namespace FirstStep.Controls
{
    using System;

    /// <summary>
    /// Расположение контрола на экране.
    /// </summary>
    [Flags]
    public enum ControlPosition
    {
        /// <summary>
        /// Сверху.
        /// </summary>
        Top = 4,

        /// <summary>
        /// Снизу.
        /// </summary>
        Bottom = 8,

        /// <summary>
        /// По-центру.
        /// </summary>
        Center = 16
    }
}