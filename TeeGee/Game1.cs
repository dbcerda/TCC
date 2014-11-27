#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Windows.Forms;
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
        private IntPtr _drawSurface;
        private Form _parentForm;
        private PictureBox _pictureBox;
        private Control _gameForm;

        public Game1(IntPtr drawSurface, Form parentForm, PictureBox surfacePictureBox)
        {
            _drawSurface = drawSurface;
            _parentForm = parentForm;
            _pictureBox = surfacePictureBox;            
            graphics = new GraphicsDeviceManager(this);            
            Content.RootDirectory = "Content";

            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            Mouse.WindowHandle = _drawSurface;

            //_gameForm = Control.FromHandle(this.Window.Handle);
            //_gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            //_gameForm.SizeChanged += new EventHandler(pictureBox_SizeChanged);
        }

        private void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (_gameForm.Visible == true)
                _gameForm.Visible = false;
        }

        private void graphics_PreparingDeviceSettings(Object sender, PreparingDeviceSettingsEventArgs evt)
        {
            evt.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = _drawSurface;

        }

        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (_parentForm.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                graphics.PreferredBackBufferWidth = _pictureBox.Width;
                graphics.PreferredBackBufferHeight = _pictureBox.Height;
                //Camera.ViewPortWidth = _pictureBox.Width;
                //Camera.ViewPortHeight = _pictureBox.Height;
                graphics.ApplyChanges();
            }
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

            this.IsMouseVisible = true;

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
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
