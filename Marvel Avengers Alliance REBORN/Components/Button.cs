using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    abstract class Button : Component
    {
        #region Field
        private MouseState currentMouse;
        private MouseState previousMouse;
        private bool isPointed;

        public event EventHandler Click;
        #endregion

        #region Poperties
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        #endregion

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            if (isPointed)
                color = Color.LightYellow;

            spriteBatch.Draw(_texture, Rectangle, color);
        }

        public override void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);

            isPointed = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                isPointed = true;

                if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
