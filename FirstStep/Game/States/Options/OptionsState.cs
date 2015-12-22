namespace FirstStep.Game.States.Options
{
    using Base;

    using Buttons;

    using Controls;

    using Domain;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Состояние нахождения на экране настроек.
    /// </summary>
    public class OptionsState : SimpleGameObject, IState
    {
        /// <summary>
        /// Набор элентов управления.
        /// </summary>
        private readonly ContolCollection _contols;

        /// <summary>
        /// Новое состояние.
        /// </summary>
        private IState _newState;

        /// <summary>
        /// Несохраненные настройки доски.
        /// </summary>
        private readonly BoardSettings _tempSettings;

        public OptionsState()
        {
            _tempSettings = Settings.Clone();
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(8)
                    .BeforeUpdate(() => _newState = null)
                    .AddControl(
                        new NumericUpDown("Board height", i => _tempSettings.BoardHeight = i, value: Settings.BoardHeight, maxValue: 30, minValue: 1))
                    .AddControl(
                        new NumericUpDown("Board width", i => _tempSettings.BoardWidth = i, value: Settings.BoardWidth, maxValue: 30, minValue: 2))
                    .AddControl(new NumericUpDown("Gold amount", i => _tempSettings.GoldAmount = i, value: Settings.GoldAmount))
                    .AddControl(new NumericUpDown("Robots amount", i => _tempSettings.RobotsAmount = i, value: Settings.RobotsAmount))
                    .AddControl(new NumericUpDown("Holes amount", i => _tempSettings.HolesAmount = i, value:Settings.HolesAmount))
                    .AddControl(new Button("Save",
                        button =>
                            {
                                Settings = _tempSettings;
                                button.Caption = "Settings saved";
                            }))
                    .AddControl(new Button("Back", () => _newState = new MainMenuState()))
                    .WithBackground(Color.FromNonPremultiplied(0,0,0,0));
        }

        /// <summary>
        /// Обновиться.
        /// </summary>
        /// <returns>Новое состояние, либо null, если состояние не изменилось.</returns>
        public IState Update()
        {
            _contols.Update();
            return _newState;
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public void Draw()
        {
            _contols.Draw();
        }
    }
}
