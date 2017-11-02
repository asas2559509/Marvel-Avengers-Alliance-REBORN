using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class Card : Button
    {
        #region Field
        private string card_name;
        private string uniform_name;

        private Character _hero;
        #endregion

        public Card(ContentManager content, string hero_name, string uniform_name)
        {
            LoadContent(content, "Cards/" + uniform_name);
        }

        public void Set_Hero(Character hero)
        {
            _hero = hero;
        }

        public Character Get_Hero()
        {
            return _hero;
        }
    }
}
