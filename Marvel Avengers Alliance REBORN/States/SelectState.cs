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
    class SelectState : MAAGame
    {
        public const int ONE_PLAYER = 1;
        public const int TWO_PLAYER = 2;

        #region Game Fields
        //private List<Character> heroes;
        //private List<MenuButton> menu_component;
        private List<Card> cards;
        private List<SelectIcon> IconBackground;
        private Background Select_background;
        private Background Stetusbar;
        //private Background empty_status_bar;
        //private Background turn_bar;
        //private Background skill_bar;
        //private int cur_turn;
        protected Viewport viewport;

        //private Background Card;
        #endregion

        public SelectState(/*List<Character> avatar*/)
        {
 
            //heroes = new List<Character>();
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1 / 15.0); // Frame rate is 15 fps.
        }

        protected override void Initialize()
        {
            Set_Windows_size(SCREEN_WIDTH, SCREEN_HEIGHT);

            Select_background = new Background();
            Stetusbar = new Background();
            //empty_status_bar = new Background();
            //turn_bar = new Background();
            //skill_bar = new Background();
            //menu_component = new List<MenuButton>();
            cards = new List<Card>();
            IconBackground = new List<SelectIcon>();
            Character[] SelectHeros = new Character[6];
            //Card = new Background();

            //cur_turn = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            viewport = graphics.GraphicsDevice.Viewport;

            Select_background.LoadContent(Content,"Select_Background/"+BG.SG_001);  //Set BackGround
            Stetusbar.LoadContent(Content, "Select_Background/" + BG.SG_002);
            Stetusbar.Position = new Vector2((Select_background.Get_Width() / 2 - (Stetusbar.Get_Width() / 2)),405);

            /*
            empty_status_bar.LoadContent(Content, "Component/" + Gadget.Empty_Status_Bar);
            empty_status_bar.Position = new Vector2(0, 630 - empty_status_bar.Get_Height());
            turn_bar.LoadContent(Content, "Component/" + Gadget.Turn_Bar);
            turn_bar.Position = new Vector2((SCREEN_WIDTH / 2) - (turn_bar.Get_Width() / 2), 0);

            
            #region Load Menu
            var btn = new MenuButton(Content, Gadget.Agent_Recharge);
            btn.Position = new Vector2(((Select_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 0) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Agent_Inventory);
            btn.Position = new Vector2(((Select_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 1) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Curative_Measure);
            btn.Position = new Vector2(((Select_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 2) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
            menu_component.Add(btn);
            btn.Click += Menu_was_Clicked;
            btn = new MenuButton(Content, Gadget.Arc_Reactor_Charge);
            btn.Position = new Vector2(((Select_background.Get_Width() - btn.Get_Width()) / 2) + ((4 - 3) * (btn.Get_Width() + 8)) - (btn.Get_Width() / 2), 496);
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
                for (int j = 0; j < 4; j++)
                {
                    var btnskill = new SkillButton(Content, heroes[i].Get_Name(), heroes[i].Get_Uniform(), heroes[i].Get_Skills()[j]);
                    btnskill.Position = new Vector2(((Select_background.Get_Width() - btnskill.Get_Width()) / 2) + ((j - 4) * (btnskill.Get_Width() + 8)) + (btnskill.Get_Width() / 2), 496);
                    btnskill.Click += BtnAttack_was_Clicked;
                    heroes[i].Add_Skill_Button(btnskill);
                }
                heroes[i]._hp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Health(), Gadget.HEALTH, Content);
                if (i % 2 == 0) heroes[i]._hp_bar.Position = new Vector2(7, SCREEN_HEIGHT - 72 + (i * 12));
                else heroes[i]._hp_bar.Position = new Vector2(389, SCREEN_HEIGHT - 72 + ((i - 1) * 12));
                heroes[i]._sp_bar = new StatusBar(heroes[i].Get_Name(), heroes[i].Get_Max_Stamina(), Gadget.STAMINA, Content);
                if (i % 2 == 0) heroes[i]._sp_bar.Position = new Vector2(7, SCREEN_HEIGHT - 62 + (i * 12));
                else heroes[i]._sp_bar.Position = new Vector2(389, SCREEN_HEIGHT - 62 + ((i - 1) * 12));

                heroes[i].Load_Sprite(Content, heroes[i].Get_Name(), heroes[i].Get_Uniform());
                if (i % 2 == 0) heroes[i].Set_Sprite_Position(new Vector2(-(i * 10), (i * 50) - (heroes[i].Get_Sprite_Height() + 100)));
                else heroes[i].Set_Sprite_Position(new Vector2(495 + (i * 10), ((i - 1) * 50) - (heroes[i].Get_Sprite_Height() + 100)));
                heroes[i].Get_Sprite().Click += Char_was_Clicked;
            }

            heroes[cur_turn].Set_Sprite_Focus(true);

            base.LoadContent();
            */

            #region CreatCrad
            var btnCard = new Card(Content, IconHeros.AntMan_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width()/2-(btnCard.Get_Width()/2))-btnCard.Get_Width()-10),50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.Deadpool_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.Hulk_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2))+btnCard.Get_Width()+10), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.Captain_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) - btnCard.Get_Width() - 10), 50+btnCard.Get_Height()+10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.X23_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50+btnCard.Get_Height()+10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.GhostRider_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) + btnCard.Get_Width() + 10), 50+btnCard.Get_Height()+10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;
            #endregion

            int[] Xposition = new int[6];
            int[] Yposition = new int[6];
            var btnIcon1 = new SelectIcon(Content, IconHeros.Background_Icon1);
            btnIcon1.Position = new Vector2(75, 405);
            Xposition[0] = 75; Yposition[0] = 405; 
            IconBackground.Add(btnIcon1);
            btnIcon1.Click += Icon_was_Clicked;

            var btnIcon2 = new SelectIcon(Content, IconHeros.Background_Icon2);
            btnIcon2.Position = new Vector2(75 + (btnIcon2.Get_Width()) + 10, 405 + (btnIcon2.Get_Height()));
            Xposition[1] = 75 + (btnIcon2.Get_Width()) + 10; Yposition[1] = 405 + (btnIcon2.Get_Height());
            IconBackground.Add(btnIcon2);
            btnIcon2.Click += Icon_was_Clicked;

            var btnIcon3 = new SelectIcon(Content, IconHeros.Background_Icon3);
            btnIcon3.Position = new Vector2(75, 405 + (btnIcon3.Get_Height() * 2));
            Xposition[2] = 75; Yposition[2] = 405 + (btnIcon3.Get_Height() * 2);
            IconBackground.Add(btnIcon3);
            btnIcon3.Click += Icon_was_Clicked;

            var btnIcon4 = new SelectIcon(Content, IconHeros.Background_Icon);
            btnIcon4.Position = new Vector2((Select_background.Get_Width()) - 75 - (btnIcon4.Get_Width()), 405);
            Xposition[3] = (Select_background.Get_Width()) - 75 - (btnIcon4.Get_Width()); Yposition[3] = 405;
            IconBackground.Add(btnIcon4);

            var btnIcon5 = new SelectIcon(Content, IconHeros.Background_Icon);
            btnIcon5.Position = new Vector2((Select_background.Get_Width()) - 75 - 10 - (btnIcon5.Get_Width() * 2), 405 + (btnIcon5.Get_Height()));
            Xposition[4] = (Select_background.Get_Width()) - 75 - 10 - (btnIcon5.Get_Width() * 2); Yposition[4] = 405 + (btnIcon5.Get_Height());
            IconBackground.Add(btnIcon5);

            var btnIcon6 = new SelectIcon(Content, IconHeros.Background_Icon);
            btnIcon6.Position = new Vector2((Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()), 405 + (btnIcon6.Get_Height()*2));
            Xposition[5] = (Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()); Yposition[5] = 405 + (btnIcon6.Get_Height() * 2);
            IconBackground.Add(btnIcon6);



        }

        private void Card_was_Clicked(object sender, EventArgs e)
        {
            switch (((Card)sender).Get_Name())
            {              
                case IconHeros.AntMan_Card:
                    {
                        break;
                    }
            }
        }

        private void Icon_was_Clicked(object sender, EventArgs e)
        {
            switch (((SelectIcon)sender).Get_Name())
            {
                case IconHeros.Background_Icon1:
                    { 
                        
                        break;
                    }
                case IconHeros.Background_Icon2:
                    {

                        break;
                    }
                case IconHeros.Background_Icon3:
                    {

                        break;
                    }
            }
        }



        /*
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
        
        
        private void BtnAttack_was_Clicked(object sender, EventArgs e)
        {
            if (heroes[cur_turn].Get_Sprite_HasTarget()) return;
            heroes[cur_turn].Set_Cur_Skill(((SkillButton)sender).Get_Skill());
            if (heroes[cur_turn].Get_Cur_Skill() == null) return;
            Console.Out.WriteLine("Skill " + ((SkillButton)sender).Get_Skill().Get_Name() + " of " + heroes[cur_turn].Get_Name() + " was Clicked");
            heroes[cur_turn].isPickSkill = true;
        }

        private void Char_was_Clicked(object sender, EventArgs e)
        {
            heroes[cur_turn].Set_Sprite_HasTarget(false);

            if (!heroes[cur_turn].isPickSkill) return;

            List<Sprite> targets = new List<Sprite>();

            if (heroes[cur_turn].Get_Cur_Skill().Get_NumberOfTargets() == TargetType.One_Enemy)
            {
                targets.Add(((Sprite)sender).Get_Me());
                Console.Out.WriteLine(targets[0].Get_Char().Get_Name() + " was Selected");
            }
            else
            {
                for (int i = 0; i < heroes.Count; i++)
                {
                    targets.Add(heroes[i].Get_Sprite());
                    if (i % 2 == 1) heroes[cur_turn].Set_Target(targets);
                }
            }
            heroes[cur_turn].Set_Target(targets);

            heroes[cur_turn].Set_Sprite_HasTarget(true);

            heroes[cur_turn].Skill_Action(Content);

            heroes[cur_turn].isPickSkill = false;
        }
        */


        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        public void Notify(Calculator engine)
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //foreach (var avatar in heroes)
            //    avatar.Play();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            /*
            foreach (var avatar in heroes)
            {
                if (avatar.Get_Sprite().Get_IsDead())
                {
                    heroes.Remove(avatar);
                    break;
                }

                avatar.Update_Sprite_Frame(gameTime, elapsed);
                avatar._hp_bar.Update(gameTime);
                avatar._sp_bar.Update(gameTime);
            }
            

            foreach (var btnskill in heroes[cur_turn].Get_Skills_Button())
                btnskill.Update(gameTime, heroes[cur_turn]);

            foreach (var btn in menu_component)
                btn.Update(gameTime);
            */
            foreach (var btnCard in cards)
                btnCard.Update(gameTime);

            foreach (var btnIcon in IconBackground)
                btnIcon.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);

            Select_background.Draw(spriteBatch);
            Stetusbar.Draw(spriteBatch);

            foreach (var btnCard in cards)
                btnCard.Draw(gameTime,spriteBatch);

            foreach (var btnIcon in IconBackground)
                btnIcon.Draw(gameTime, spriteBatch);


            //Card.Draw(spriteBatch);
            /*
            empty_status_bar.Draw(spriteBatch);

            foreach (var btn in menu_component)
                btn.Draw(gameTime, spriteBatch);
            
            foreach (var avatar in heroes)
            {
                avatar.Draw_Sprite(gameTime, spriteBatch);
                avatar._hp_bar.Draw(spriteBatch);
                avatar._sp_bar.Draw(spriteBatch);
            }
            
            
            
            foreach (var btnskill in heroes[cur_turn].Get_Skills_Button())
                btnskill.Draw(gameTime, spriteBatch);

            turn_bar.Draw(spriteBatch);
            */


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
