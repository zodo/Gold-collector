

namespace FirstStep
{
    using System;

    using Game.States;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public partial class GoldGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        public SpriteFont Font;
        public Texture2D WhiteRectangle;

        private IState _state;

        private static GoldGame Instance { get; set; }

        private static bool _instantied;

        public GoldGame()
        {
            if (_instantied)
            {
                throw new InvalidOperationException($"{nameof(GoldGame)} can be instancied only once");
            }
            _instantied = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            //TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 100.0f);
            //graphics.SynchronizeWithVerticalRetrace = true;
            _state = new MainMenuState();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
