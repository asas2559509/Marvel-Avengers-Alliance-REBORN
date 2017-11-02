using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.DATA.Heroes
{
    class New_Hero : Character
    {
        public New_Hero(ContentManager content)
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
            
            this._cur_health = _max_health;
            this._cur_health = _max_stamina;
            #endregion

            #region Set 1st Attack
            Skill skill = new Skill("Ant-Man-Break_In");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(18);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(999, 9999);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(2);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            SkillButton btnskill = new SkillButton(content, name, alternate_uniform, skill.Get_Name());

            _skill_buttons.Add(btnskill);
            #endregion

            #region Set 2nd Attack
            skill = new Skill("Ant-Man-Greatest_Allies");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(999, 9999);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            btnskill = new SkillButton(content, name, alternate_uniform, skill.Get_Name());

            _skill_buttons.Add(btnskill);
            #endregion

            #region Set 3rd Attack
            skill = new Skill("Ant-Man-Pint-Size_Surprise");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(23);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(999, 9999);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(88);
            skill.Set_Cri_Chance(11);

            btnskill = new SkillButton(content, name, alternate_uniform, skill.Get_Name());

            _skill_buttons.Add(btnskill);
            #endregion

            #region Set 4th Attack
            skill = new Skill("Ant-Man-Swarm_Cloud");
            skill.Set_Time(5);
            skill.Set_Stamina_Cost(5);
            skill.Set_NumberOfTargets(TargetType.One_Enemy);
            skill.Set_Damage(999, 9999);
            skill.Set_Cooldown(0, 0);
            skill.Set_NumberOfHits(1);
            skill.Set_Hits_Chance(100);
            skill.Set_Cri_Chance(60);

            btnskill = new SkillButton(content, name, alternate_uniform, skill.Get_Name());

            _skill_buttons.Add(btnskill);
            #endregion
        }
    }
}
