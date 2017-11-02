using Marvel_Avengers_Alliance_REBORN.Buttons;
using Marvel_Avengers_Alliance_REBORN.Components;
using Marvel_Avengers_Alliance_REBORN.DATA;
using Marvel_Avengers_Alliance_REBORN.DATA.Heroes;
using Marvel_Avengers_Alliance_REBORN.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Avengers_Alliance_REBORN.States
{
    class BattleState : MAAGame
    {
        public const int ONE_PLAYER = 1;
        public const int TWO_PLAYER = 2;

        Calculator engine;

        #region Game Fields
        private List<Character> heroes;
        private List<MenuButton> menu_component;

        private Background combat_background;
        private Background empty_status_bar;
        private Background turn_bar;
        private Background skill_bar;
        private int cur_turn;
        protected Viewport viewport;
        #endregion

        public BattleState(/*List<Character> avatar*/)
        {
            heroes = new List<Character>();
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }

        protected override void Initialize()
        {
            Set_Windows_size(SCREEN_WIDTH, SCREEN_HEIGHT);

            engine = new Calculator();

            combat_background = new Background();
            empty_status_bar = new Background();
            turn_bar = new Background();
            skill_bar = new Background();
            menu_component = new List<MenuButton>();

            cur_turn = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            viewport = graphics.GraphicsDevice.Viewport;

            combat_background.LoadContent(Content, "Combat_Background/" + BG.BG_011);  //Set BackGround

            empty_status_bar.LoadContent(Content, "Component/" + Gadget.Empty_Status_Bar);
            empty_status_bar.Position = new Vector2(0, 630 - empty_status_bar.Get_Height());
            turn_bar.LoadContent(Content, "Component/" + Gadget.Turn_Bar);
            turn_bar.Position = new Vector2((SCREEN_WIDTH / 2) - (turn_bar.Get_Width() / 2), 0);

            #region Load Menu
            var btn = new MenuButton(Content, Gadget.Agent_Recharge);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 0) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Agent_Inventory);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 1) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Curative_Measure);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 2) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Arc_Reactor_Charge);
            btn.Position = new Vector2(((combat_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 3) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            #endregion

            heroes.Add(new Ant_Man(Content));
            heroes.Add(new Ant_Man(Content));
            heroes.Add(new Ant_Man(Content));

            heroes.Add(new Ant_Man(Content));
            heroes.Add(new Ant_Man(Content));
            heroes.Add(new Ant_Man(Content));

            for (int i = 0; i < heroes.Count; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    heroes[i].Get_SkillButton()[j] = new SkillButton(Content, heroes[i].Get_Name(), heroes[i].Get_Uniform(), heroes[i].Get_SkillButton()[j].Get_Skill());
                    heroes[i].Get_SkillButton()[j].Position = new Vector2(((combat_background.Get_Width() - heroes[i].Get_SkillButton()[j].Get_Width()) / 2) + ((j - 4) * (heroes[i].Get_SkillButton()[j].Get_Width() + 8)) + (heroes[i].Get_SkillButton()[j].Get_Width() / 2), 496);
                    heroes[i].Get_SkillButton()[j].Click += BtnAttack_was_Clicked;
                }
                heroes[i]._hp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Health(),Gadget.HEALTH, Content);
                if (i % 2 == 0) heroes[i]._hp_bar.Position = new Vector2(7, SCREEN_HEIGHT - 72 + (i * 12));
                else heroes[i]._hp_bar.Position = new Vector2(389, SCREEN_HEIGHT - 72 + ((i - 1) * 12));
                heroes[i]._sp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Stamina(), Gadget.STAMINA, Content);
                if (i % 2 == 0) heroes[i]._sp_bar.Position = new Vector2(7, SCREEN_HEIGHT - 62 + (i * 12));
                else heroes[i]._sp_bar.Position = new Vector2(389, SCREEN_HEIGHT - 62 + ((i - 1) * 12));

                heroes[i].Load_Sprite(Content, heroes[i].Get_Name(), heroes[i].Get_Uniform());
                if(i % 2 == 0) heroes[i].Set_Sprite_Position(new Vector2(-(i * 10), (i * 50) - (heroes[i].Get_Sprite_Height() + 100)));
                else heroes[i].Set_Sprite_Position(new Vector2(495 + (i * 10), ((i - 1) * 50) - (heroes[i].Get_Sprite_Height() + 100)));
                heroes[i].Click += Char_was_Clicked;
            }
            
            heroes[cur_turn].Set_Sprite_Focus(true);

            base.LoadContent();
        }

        private void Menu_was_Clicked(object sender, EventArgs e)
        {
            switch (((MenuButton)sender).Get_Name())
            {
                case Gadget.Agent_Recharge:
                    {
                        heroes[cur_turn].Set_Sprite_Focus(false);
                        if (cur_turn >= heroes.Count - 1) cur_turn = 0;
                        else cur_turn++;
                        heroes[cur_turn].Set_Sprite_Focus(true);
                        break;
                    }
                case Gadget.Arc_Reactor_Charge:
                    {
                        break;
                    }
                case Gadget.Curative_Measure:
                    {
                        break;
                    }
                case Gadget.Agent_Inventory:
                    {
                        break;
                    }
            }
        }

        SkillButton cur_btn;

        private void BtnAttack_was_Clicked(object sender, EventArgs e)
        {
            heroes[cur_turn].Set_Cur_Skill(((SkillButton)sender).Get_Skill());
            heroes[cur_turn].isPickSkill = true;
            Console.Out.WriteLine("Click " + ((SkillButton)sender).Get_Skill().Get_Name());
        }

        private void Char_was_Clicked(object sender, EventArgs e)
        {
            if (!heroes[cur_turn].isPickSkill) return;

            if (heroes[cur_turn].Get_Cur_Skill().Get_NumberOfTargets() == TargetType.One_Enemy)
            {
                heroes[cur_turn]._targets.Add(((Character)sender).Get_Me());
            }
            else
            {
                for(int i = 0; i < heroes.Count; i++)
                {
                    if(i % 2 == 1) heroes[cur_turn]._targets.Add(heroes[i]);
                }
            }
            heroes[cur_turn].Skill_Action(Content);

            heroes[cur_turn].Set_Sprite_HasTarget(true);

            heroes[cur_turn].isPickSkill = false;
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void Notify(Calculator engine)
        {

        }

        protected override void Update(GameTime gameTime)
        {
            foreach (var avatar in heroes)
                avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var avatar in heroes)
            {
                avatar.Update_Sprite_Frame(gameTime, elapsed);
                avatar._hp_bar.Update(gameTime);
                avatar._sp_bar.Update(gameTime);
            }

                foreach (var btn in menu_component)
                btn.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(sortMode:SpriteSortMode.BackToFront);
            
            combat_background.Draw(spriteBatch);

            empty_status_bar.Draw(spriteBatch);

            foreach (var btn in menu_component)
                btn.Draw(gameTime,spriteBatch);

            foreach (var avatar in heroes)
            {
                avatar.Draw_Sprite(gameTime, spriteBatch);
                avatar._hp_bar.Draw(spriteBatch);
                avatar._sp_bar.Draw(spriteBatch);
            }

            turn_bar.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected void Set_Windows_size(int width, int height)
        {
            graphics.PreferredBackBufferWidth = width;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = height;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }
    }
}
