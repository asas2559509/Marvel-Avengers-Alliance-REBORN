using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Components
{
    class Background : Component
    {
        public Background()
        {

        }

        public override void LoadContent(ContentManager content, string asset)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public override void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var color = Color.White;

            spriteBatch.Draw(_texture, Position, color);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
