using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.Models
{
    class Character
    {
        #region Field
        protected string name;
        protected string alternate_uniform;
        protected int _max_health;
        protected int _cur_health;
        protected int _max_stamina;
        protected int _cur_stamina;
        protected int _attack;
        protected int _defense;
        protected int _accuracy;
        protected int _evasion;
        protected _Class _class;

        protected List<SkillButton> _skill_buttons = new List<SkillButton>();
        protected List<Character> _targets = new List<Character>();
        protected Sprite _sprite;

        public Skill cur_skill;
        public StatusBar _hp_bar;
        public StatusBar _sp_bar;
        public EventHandler Click;

        //public Vector2 Position { get; set; }
        #endregion

        #region Get Function
        public int Get_Sprite_Height()
        {
            return _sprite.Get_Sprite_Height();
        }

        public int Get_Sprite_Width()
        {
            return _sprite.Get_Sprite_Width();
        }

        public string Get_Name()
        {
            return name;
        }

        public string Get_Uniform()
        {
            return alternate_uniform;
        }

        public int Get_Max_Stamina()
        {
            return _max_stamina;
        }

        public int Get_Health()
        {
            return _cur_health;
        }

        public int Get_Max_Health()
        {
            return _max_stamina;
        }

        public int Get_Stamina()
        {
            return _cur_stamina;
        }

        public int Get_Attack()
        {
            return _attack;
        }

        public int Get_Defense()
        {
            return _defense;
        }

        public int Get_Accuracy()
        {
            return _accuracy;
        }

        public int Get_Evasion()
        {
            return _evasion;
        }

        public _Class Get_Class()
        {
            return _class;
        }

        public Character Get_Me()
        {
            return this;
        }

        public List<SkillButton> Get_SkillButton()
        {
            return _skill_buttons;
        }
        #endregion

        #region Set Function
        public void Load_Sprite(ContentManager content, string hero_name, string uniform_name)
        {
            _sprite = new Sprite(content, hero_name, uniform_name);
        }
        public void Set_Sprite_Position(Vector2 vector)
        {
            _sprite.Position = vector;
        }
        public void Set_Sprite_Focus(bool logic)
        {
            _sprite.Set_IsFocus(logic);
        }

        public void Set_Health(int cur_health)
        {
            _cur_health = cur_health;
        }

        public void Set_Stamina(int cur_stamina)
        {
            _cur_stamina = cur_stamina;
        }

        public void Set_Attack(int attack)
        {
            _attack = attack;
        }

        public void Set_Defense(int defense)
        {
            _defense = defense;
        }

        public void Set_Accuracy(int accuracy)
        {
            _accuracy = accuracy;
        }

        public void Set_Evasion(int evasion)
        {
            _evasion = evasion;
        }

        public void Set_Class(_Class _class)
        {
            this._class = _class;
        }

        public void Set_Target(List<Character> targets)
        {
            _targets = targets;
        }
        #endregion

        #region Order Function
        public void Draw_Sprite(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _sprite.DrawFrame(spriteBatch);
            foreach (var btnskill in _skill_buttons)
                btnskill.Draw(gameTime, spriteBatch);
        }

        public void Update_Sprite_Frame(GameTime gameTime, float elapsed)
        {
            _sprite.UpdateFrame(elapsed);
            foreach (var btnskill in _skill_buttons)
                btnskill.Update(gameTime);
        }
        #endregion

        #region FrameControl Function
        public bool IsPaused
        {
            get { return _sprite.IsPaused; }
        }

        public void Reset()
        {
            _sprite.Reset();
        }

        public void Stop()
        {
            _sprite.Stop();
        }

        public void Play()
        {
            _sprite.Play();
        }

        public void Pause()
        {
            _sprite.Pause();
        }
        #endregion
    }
}
