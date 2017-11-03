using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Buttons
{
    class SkillButton : Button
    {
        private Skill _skill;
        private Texture2D _skill_texture;

        public SkillButton(ContentManager content, string hero_name, string uniform_name, Skill skill)
        {
            _skill = skill;
            LoadContent(content,"Character/" + hero_name + "/" + uniform_name + "/" + skill.Get_Name());
            _skill_texture = content.Load<Texture2D>("Character/" + hero_name + "/" + uniform_name + "/" + "Sprite_" + skill.Get_Name());
        }

        public Skill Get_Skill()
        {
            return _skill;
        }

        public SkillButton Get_me()
        {
            return this;
        }

        public Texture2D Get_Skill_Texture()
        {
            return _skill_texture;
        }
    }
}
