using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace TeeGeeSim
{
    class GameManager : GameBehaviour
    {        
        private Rectangle viewArea;
        private Character characterA;
        private Character characterB;
        private Texture2D bgTexture;
        private Color bgColor;
        private GraphicsDevice graphicsDevice;

        public GameManager(Rectangle viewArea, GraphicsDeviceManager graphicsDeviceManager)
        {
            this.viewArea = viewArea;
            characterA = new Character();
            characterB = new Character();
            AddChild(characterA);
            AddChild(characterB);
            graphicsDeviceManager.DeviceCreated +=
                new EventHandler<EventArgs>(graphics_DeviceReady);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (graphicsDevice != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(bgTexture, viewArea, bgColor);
                spriteBatch.End();
            }
        }

        public void graphics_DeviceReady(Object sender, EventArgs evt)
        {
            var graphicsDeviceManager = (GraphicsDeviceManager)sender;
            graphicsDevice =  graphicsDeviceManager.GraphicsDevice;
            bgTexture = new Texture2D(graphicsDevice, 1, 1);
            bgTexture.SetData(new Color[] { Color.White });
            bgColor = new Color(1, 1, 1);
        }
    }
}
