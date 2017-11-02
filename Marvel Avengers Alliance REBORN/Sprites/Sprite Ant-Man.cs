using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Marvel_Avengers_Alliance_REBORN.Sprites
{
    /*class Sprite_Ant_Man : Sprite
    {
        public Sprite_Ant_Man(ContentManager content,string uniform_name)
        {
            ChangeSprite(content.Load<Texture2D>("Character/" + Hero.Ant_Man + "/" + uniform_name + "/" + uniform_name + "_Main"), 15, 4);

            _main_texture = _cur_texture;

            _was_hit_texture = content.Load<Texture2D>("Character/" + Hero.Ant_Man + "/" + uniform_name + "/" + uniform_name + "_was_Hit");

            for (int i = 1; i <= 4; i++)
            {
                _skill_texture.Add(content.Load<Texture2D>("Character/" + Hero.Ant_Man + "/" + uniform_name + "/Skill_" + i));
            }
        }

        public override void Animating_Skill_1st()
        {
            throw new NotImplementedException();
        }

        public override void Animating_Skill_2nd()
        {
            Vector2 goal = _targets[0].Position;
            Transition(Position, goal, 1, 5);
            Transition(goal, Position, 70, 5);
        }

        public override void Animating_Skill_3rd()
        {
            throw new NotImplementedException();
        }

        public override void Animating_Skill_4th()
        {
            throw new NotImplementedException();
        }
    }*/
}
