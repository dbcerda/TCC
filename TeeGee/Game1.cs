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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            base.Draw(gameTime);
        }

    }
}
