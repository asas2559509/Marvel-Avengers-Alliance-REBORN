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
        private Character NameChar;

        #endregion

        public Card(ContentManager content, string uniform_name)
        {
            
            card_name = uniform_name;
            LoadContent(content, "Cards/" + uniform_name);
        }


        public string Get_Name()
        {
            return card_name;
        }
    }
}

