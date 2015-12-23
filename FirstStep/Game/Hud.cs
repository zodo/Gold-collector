namespace FirstStep.Game
{
    using Microsoft.Xna.Framework;

    using Observer;

    /// <summary>
    /// Отображатель доп. информации.
    /// </summary>
    public class Hud : InteractiveGameObject, IObserver
    {
        /// <summary>
        /// Кол-во ходов.
        /// </summary>
        private int MovesAmount { get; set; }

        /// <summary>
        /// Кол-во собранного золота.
        /// </summary>
        private int GoldAmount { get; set; }

        /// <summary>
        /// Оставшиеся заряды пушки.
        /// </summary>
        private int ChargesLeft { get; set; }


        public Hud()
        {
            ChargesLeft = Settings.Charges;
        }
        
        /// <summary>
        /// При оповещении.
        /// </summary>
        /// <param name="obj">Игровой объект.</param>
        /// <param name="gameEvent">Событие.</param>
        public void OnNotify(GameObject obj, GameEvent gameEvent)
        {
            if (gameEvent == GameEvent.PlayerWalked)
            {
                MovesAmount++;
            }
            if (gameEvent == GameEvent.GoldTaken)
            {
                GoldAmount++;
            }
            if (gameEvent == GameEvent.WeaponUsed)
            {
                ChargesLeft--;
            }
        }

        /// <summary>
        /// Обновить состояние.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Отрисоваться на экране.
        /// </summary>
        public override void Draw()
        {
            var width = 250;
            var height = 40;
            var x = Game.Graphics.PreferredBackBufferWidth - width - 10;
            var y = 10;
            var rect = new Rectangle(x, y, width, height);
            Game.SpriteBatch.Draw(Game.WhiteRectangle, rect, Color.FromNonPremultiplied(255, 255, 255, 155));
            rect.X += 5;
            rect.Y += 5;
            rect.Width -= 10;
            rect.Height -= 10;
            DrawString($"Moves: {MovesAmount} Gold: {GoldAmount} Charges: {ChargesLeft}", rect, Color.Brown);
        }

        /// <summary>
        /// Возвращает объект <see cref="T:System.String" />, который представляет текущий объект <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.String" />, представляющий текущий объект <see cref="T:System.Object" />.
        /// </returns>
        public override string ToString()
        {
            return $"Moves: {MovesAmount} Gold: {GoldAmount}";
        }
    }
}