using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeeGeeSim
{
    public delegate void UpdateEventHandler(GameTime gameTime);
    public delegate void DrawEventHandler(GameTime gameTime, SpriteBatch spriteBatch);

    class GameBehaviour
    {
        List<GameBehaviour> children = new List<GameBehaviour>();
        GameBehaviour parent;

        public event UpdateEventHandler OnUpdate;
        public event DrawEventHandler OnDraw;

        public void AddChild(GameBehaviour child)
        {
            child.parent = this;
            if(children.Contains(child))
            {
                throw new Exception("Adding the same child twice");
            }
            children.Add(child);
        }

        public void RemoveChild(GameBehaviour child)
        {
            children.Remove(child);
        }

        public virtual void Update(GameTime gameTime)
        {
            if(OnUpdate != null) OnUpdate(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(OnDraw != null) OnDraw(gameTime, spriteBatch);
        }

        public void StartUpdating()
        {
            parent.OnUpdate += Update;
        }

        public void StartDrawing()
        {
            parent.OnDraw += Draw;
        }

        public void StopUpdating()
        {
            parent.OnUpdate -= Update;
        }

        public void StopDrawing()
        {
            parent.OnDraw -= Draw;
        }
    }
}
