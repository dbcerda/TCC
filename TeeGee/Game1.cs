#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace TeeGee
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    ///     

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private AnimatedSprite animatedSprite;
        private Viewport leftViewport;
        private Viewport rightViewport;
        private Viewport original;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
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

            leftViewport = new Viewport();
            leftViewport.X = 0;
            leftViewport.Y = 0;
            leftViewport.Width = 400;
            leftViewport.Height = 480;
            leftViewport.MinDepth = 0;
            leftViewport.MaxDepth = 1;

            rightViewport = new Viewport();
            rightViewport.X = 400;
            rightViewport.Y = 0;
            rightViewport.Width = 400;
            rightViewport.Height = 480;
            rightViewport.MinDepth = 0;
            rightViewport.MaxDepth = 1;

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

            Texture2D texture = Content.Load<Texture2D>("Stuff/fighter2");
            animatedSprite = new AnimatedSprite(texture, 1, 2);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Game A update
            animatedSprite.Update();

            //Game B update
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            original = graphics.GraphicsDevice.Viewport;

            //Game A rendering
            graphics.GraphicsDevice.Viewport = leftViewport;
            animatedSprite.Draw(spriteBatch, new Vector2(100  , 200));            

            //Game B rendering
            graphics.GraphicsDevice.Viewport = rightViewport;
            animatedSprite.Draw(spriteBatch, new Vector2(200, 200));

            GraphicsDevice.Viewport = original;
            
            base.Draw(gameTime);
        }
    }
}
