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
    class SkillButton : Button
    {
        Skill skill;
        private string btn_name;

        public SkillButton(ContentManager content, string hero_name, string uniform_name, string skill_name)
        {
            btn_name = skill_name;
            LoadContent(content,"Character/" + hero_name + "/" + uniform_name + "/" + skill_name);
        }

        public Skill Get_Skill()
        {
            return skill;
        }

        public string Get_Name()
        {
            return btn_name;
        }
    }
}
