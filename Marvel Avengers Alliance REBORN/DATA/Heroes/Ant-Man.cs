using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.DATA.Heroes
{
    class Ant_Man : Character
    {
        public Ant_Man(ContentManager content)
        {
            #region Set Stat
            name = Hero.Ant_Man;
            alternate_uniform = Suit.Ant_Man_Modern;
            _max_health = 6438;
            _max_stamina = 7868;
            _attack = 1431;
            _defense = 1288;
            _accuracy = 1431;
            _evasion = 1574;
            _class = _Class.Infiltrator;
            
            _cur_health = _max_health;
            _cur_stamina = _max_stamina;
            #endregion

            #region Set 1st Attack
            _skills = new List<Skill>();
            _skills_buttons = new List<SkillButton>();
            Skill skill = new Skill("Ant-Man-Break_In");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(18);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1072, 1286);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Ant-Man-Greatest_Allies");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(241, 288);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            _skills.Add(skill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Ant-Man-Pint-Size_Surprise");
            skill.Set_Time(3);
            skill.Set_Stamina_Cost(23);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(1146, 1375);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            _skills.Add(skill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Ant-Man-Swarm_Cloud");
            skill.Set_Time(4);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(510, 612);
            skill.Set_Cooldown(1, 1);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            _skills.Add(skill);
            #endregion
        }

        #region Animation Editor
        /*public override void Animating_Skill_1st()
        {
            Vector2 goal = new Vector2(Get_Sprite().Get_Targets()[0].Position.X - (Get_Sprite().Get_Targets()[0].Get_Sprite_Width() / 8), Get_Sprite().Get_Targets()[0].Position.Y);
            Get_Sprite().Transition(Get_Sprite().Position, goal, 1, 20);
            Get_Sprite().Transition(goal, Get_Sprite().Position, 50, 25);
        }

        public override void Animating_Skill_2nd()
        {
            Vector2 goal = new Vector2(Get_Sprite().Get_Targets()[0].Position.X - (Get_Sprite().Get_Targets()[0].Get_Sprite_Width() / 8), Get_Sprite().Get_Targets()[0].Position.Y);
            Get_Sprite().Transition(Get_Sprite().Position, goal, 1, 20);
            Get_Sprite().Transition(goal, Get_Sprite().Position, 50, 25);
        }

        public override void Animating_Skill_3rd()
        {
            Vector2 goal = new Vector2(Get_Sprite().Get_Targets()[0].Position.X - (Get_Sprite().Get_Targets()[0].Get_Sprite_Width() / 8), Get_Sprite().Get_Targets()[0].Position.Y);
            Get_Sprite().Transition(Get_Sprite().Position, goal, 1, 20);
            Get_Sprite().Transition(goal, Get_Sprite().Position, 50, 25);
        }

        public override void Animating_Skill_4th()
        {
            Vector2 goal = new Vector2(Get_Sprite().Get_Targets()[0].Position.X - (Get_Sprite().Get_Targets()[0].Get_Sprite_Width() / 8), Get_Sprite().Get_Targets()[0].Position.Y);
            Get_Sprite().Transition(Get_Sprite().Position, goal, 1, 20);
            Get_Sprite().Transition(goal, Get_Sprite().Position, 50, 25);
        }*/
        #endregion

        /*public void Check_Skill()
        {
            switch (_cur_skill.Get_Name())
            {
                case "Ant-Man-Break_In":
                    {
                        Animating_Skill_1st();
                        break;
                    }
                case "Ant-Man-Greatest_Allies":
                    {
                        Animating_Skill_2nd();
                        break;
                    }
                case "Ant-Man-Pint-Size_Surprise":
                    {
                        Animating_Skill_3rd();
                        break;
                    }
                case "Ant-Man-Swarm_Cloud":
                    {
                        Animating_Skill_4th();
                        break;
                    }
            }
        }*/
    }
}
