namespace FirstStep
{
    using System;

    using Game;
    using Game.States;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Основной класс игры.
    /// </summary>
    public partial class MainGame : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Настройки игры.
        /// </summary>
        private static GameSettings _settings = new GameSettings();

        /// <summary>
        /// Состояние.
        /// </summary>
        private State _state;
        
        public GraphicsDeviceManager Graphics { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public SpriteFont Font { get; private set; }

        /// <summary>
        /// Текстура белого квадрата.
        /// </summary>
        /// <remarks>Нужна для отрисовки примитивов.</remarks>
        public Texture2D WhiteRectangle { get; private set; }

        /// <summary>
        /// Инстанс.
        /// </summary>
        private static MainGame _instance;

        public MainGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _instance = this;
        }

        protected override void Initialize()
        {
            GraphicsDevice.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;
            Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            Graphics.IsFullScreen = true;
            Graphics.ApplyChanges();
            _state = new MainMenuState();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            WhiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            WhiteRectangle.SetData(new[] { Color.White });
            Font = Content.Load<SpriteFont>("MyFont");
        }

        protected override void Update(GameTime gameTime)
        {
            _state = _state.Update() ?? _state;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            SpriteBatch.Begin();
            {
                _state.Draw();
            }
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}