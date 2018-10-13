﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnowGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        // Lazy statics:
        public static Main instance;

        // Monogame core:
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // SnowGame core:
        Core.Managers.SceneManager sceneManager;
        Core.Managers.GameManager gameManager;
        Core.Managers.CollisionManager collisionManager;
        Core.Camera.Camera myCamera;

        // TEMP
        private SnowGame.Scenes.Menu Menu;
        private SnowGame.Scenes.MainGame MainGame;

        private int toggle = 0;

        /// <summary>
        /// Entry point to game:
        /// </summary>
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);


            // Set preferred height/width of the game:
            graphics.PreferredBackBufferWidth = Core.Config.GameConfiguration.DEFAULT_WIDTH;
            graphics.PreferredBackBufferHeight = Core.Config.GameConfiguration.DEFAULT_HEIGHT;
           // graphics.IsFullScreen = true;
            
            Content.RootDirectory = "Content";  
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

            // Initialise statics
            Main.instance = this;

            // Make game manager:
            gameManager = Core.Managers.GameManager.Instance;
            gameManager.Init(this.Content, this.GraphicsDevice);

            // Make collision manager:
            collisionManager = Core.Managers.CollisionManager.Instance;

            // Make scene manager:
            sceneManager = Core.Managers.SceneManager.Instance;

            // Make Camera:
            myCamera = new Core.Camera.Camera(GraphicsDevice.Viewport);
            collisionManager.Init(myCamera, true);

            // Scenes, these will move to where they are needed in future:
            Menu = new SnowGame.Scenes.Menu();
            MainGame = new SnowGame.Scenes.MainGame();

            // Attach scenes to manager .. again not really needed here
            sceneManager.AddScene(Menu);
            sceneManager.AddScene(MainGame);

            // Lets start with the Menu cuz thats the easiest:
            sceneManager.ActivateScene(MainGame);


            // Calling base.Initialize will enumerate through any components
            // and initialize them as well.
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Check if user attempted to exit game:
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here:
            sceneManager.Update( gameTime );

            // Update collisions:
            collisionManager.Update(sceneManager.ActiveScene.defaultCamera);

            // BASE - update main game with dT.
            base.Update(gameTime);
        }

        /// Heading out for a bit - back on later.

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            sceneManager.Draw();

            base.Draw(gameTime);
        }
    }
}
