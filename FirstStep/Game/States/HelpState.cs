namespace FirstStep.Game.States
{
    using Controls;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Состояние нахождения в справке.
    /// </summary>
    public class HelpState : State
    {
        /// <summary>
        /// Элементы управления.
        /// </summary>
        private readonly ContolCollection _contols;

        public HelpState()
        {
            _contols =
                ContolCollection.Create()
                    .AtCoords(ControlPosition.Center)
                    .SetSize(5)
                    .WithBackground(Color.Transparent)
                    .BeforeUpdate(() => NewState = null)
                    .AddHeader("Movements - arrows", 4)
                    .AddHeader(" Freezer - space  ", 4)
                    .AddHeader("Collect gold, avoid robots", 5)
                    .AddControl(new Button("Back", () => NewState = new MainMenuState()));
        }

        /// <summary>
        /// Отрисоваться.
        /// </summary>
        public override void Draw()
        {
            _contols.Draw();
        }

        /// <summary>
        /// Выполнить обновление.
        /// </summary>
        protected override void DoUpdate()
        {
            _contols.Update();
        }
    }
}
