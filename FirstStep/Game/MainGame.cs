namespace FirstStep
{
    using System;

    using Board;

    using Game.States;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Основной тип с игровым циклом.
    /// </summary>
    public partial class MainGame : Microsoft.Xna.Framework.Game
    {
        private static GameSettings _settings = new GameSettings();

        private static bool _instantied;

        private IState _state;

        public MainGame()
        {
            if (_instantied)
            {
                throw new InvalidOperationException($"{nameof(MainGame)} can be instancied only once");
            }
            _instantied = true;
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _instance = this;
        }

        public GraphicsDeviceManager Graphics { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public SpriteFont Font { get; private set; }

        public Texture2D WhiteRectangle { get; private set; }

        private static MainGame _instance { get; set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Graphics.PreferredBackBufferWidth = 1024;
            Graphics.PreferredBackBufferHeight = 700;

            _state = new MainMenuState();
            GraphicsDevice.PresentationParameters.RenderTargetUsage = RenderTargetUsage.PreserveContents;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            WhiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            WhiteRectangle.SetData(new[] { Color.White });
            // TODO: use this.Content to load your game content here
            Font = Content.Load<SpriteFont>("MyFont");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            _state = _state.Update() ?? _state;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here

            SpriteBatch.Begin();

            _state.Draw();

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}