using Marvel_Avengers_Alliance_REBORN.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    public abstract class Component
    {
        #region Field
        protected Texture2D _texture;
        protected ArrayList oList;
        #endregion

        #region Poperties
        public Vector2 Position { get; set; }
        #endregion

        public int Get_Height()
        {
            return _texture.Height;
        }

        public int Get_Width()
        {
            if(_texture != null) return _texture.Width;
            return 0;
        }

        public abstract void LoadContent(ContentManager content, string asset);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
