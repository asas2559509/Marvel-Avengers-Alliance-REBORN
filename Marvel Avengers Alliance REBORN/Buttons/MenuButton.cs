using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class MenuButton : Button
    {
        public MenuButton(ContentManager content, string component_name)
        {
            LoadContent(content, "Component/" + component_name);
        }
    }
}
