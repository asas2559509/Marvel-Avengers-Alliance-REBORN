using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Marvel_Avengers_Alliance_REBORN.Components
{
    class Icon : Component
    {
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Icon(ContentManager content, string hero_name, string icon_name)
        {
            LoadContent(content, hero_name +"/" + icon_name);
        }

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            spriteBatch.Draw(_texture, Rectangle, color);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
