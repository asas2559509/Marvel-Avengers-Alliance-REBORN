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
        private List<Character> heroes;
        private List<Card> cards;
        private List<SelectIcon> IconBackground;
        private List<SelectIcon> IconHero;
        private List<SelectIcon> HeroSelect;
        private List<SelectIcon> HerosStatus;


        private Background Select_background;
        private Background Stetusbar;

        int numSelect = 0;

        int[] Xposition = new int[7];
        int[] Yposition = new int[7];
        protected Viewport viewport;

        #endregion

        public SelectState(/*List<Character> avatar*/)
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

            Select_background = new Background();
            Stetusbar = new Background();
            cards = new List<Card>();
            IconBackground = new List<SelectIcon>();
            IconHero = new List<SelectIcon>();
            HeroSelect = new List<SelectIcon>();
            HerosStatus = new List<SelectIcon>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            viewport = graphics.GraphicsDevice.Viewport;

            Select_background.LoadContent(Content, "Select_Background/" + BG.SG_001);  //Set BackGround
            Stetusbar.LoadContent(Content, "Select_Background/" + BG.SG_002);
            Stetusbar.Position = new Vector2((Select_background.Get_Width() / 2 - (Stetusbar.Get_Width() / 2)), 405);
            Xposition[6] = (Select_background.Get_Width() / 2 - (Stetusbar.Get_Width() / 2));
            Yposition[6] = 405;

            #region CreatCrad
            var btnCard = new Card(Content, IconHeros.Deadpool_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) - btnCard.Get_Width() - 10), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.AntMan_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.Hulk_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) + btnCard.Get_Width() + 10), 50);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.Captain_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) - btnCard.Get_Width() - 10), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.X23_Card);
            btnCard.Position = new Vector2((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;

            btnCard = new Card(Content, IconHeros.GhostRider_Card);
            btnCard.Position = new Vector2(((Select_background.Get_Width() / 2 - (btnCard.Get_Width() / 2)) + btnCard.Get_Width() + 10), 50 + btnCard.Get_Height() + 10);
            cards.Add(btnCard);
            btnCard.Click += Card_was_Clicked;
            #endregion

            #region BackgroundIcon

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
            btnIcon6.Position = new Vector2((Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()), 405 + (btnIcon6.Get_Height() * 2));
            Xposition[5] = (Select_background.Get_Width()) - 75 - (btnIcon6.Get_Width()); Yposition[5] = 405 + (btnIcon6.Get_Height() * 2);
            IconBackground.Add(btnIcon6);
            #endregion

            #region Stadard Heeros
            var btnIconDeadpool = new SelectIcon(Content, IconHeros.Deadpool_Icon);
            btnIconDeadpool.Position = new Vector2(Xposition[0], Yposition[0]);
            HeroSelect.Add(btnIconDeadpool);
            btnIconDeadpool.Click += Icon_was_Clicked;

            var btnIconAntMan = new SelectIcon(Content, IconHeros.AntMan_Icon);
            btnIconAntMan.Position = new Vector2(Xposition[1], Yposition[1]);
            HeroSelect.Add(btnIconAntMan);
            btnIconAntMan.Click += Icon_was_Clicked;

            var btnIconHulk = new SelectIcon(Content, IconHeros.Hulk_Icon);
            btnIconHulk.Position = new Vector2(Xposition[2], Yposition[2]);
            HeroSelect.Add(btnIconHulk);
            btnIconHulk.Click += Icon_was_Clicked;
            #endregion

            #region Stadard Status
            var DeadpoolStatus = new SelectIcon(Content, IconHeros.Deadpool_Status);
            DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
            HerosStatus.Add(DeadpoolStatus);
            #endregion
        }

        private void Icon_was_Clicked(object sender, EventArgs e)
        {
            if (((SelectIcon)sender).Get_Name() == HeroSelect[0].Get_Name())
            {

                if (HeroSelect[0].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(Content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(Content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(Content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[0].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(Content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[0].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(Content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[0].Get_Name() == "GhostRider_Icon")
                {

                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[1].Get_Name())
            {
                if (HeroSelect[1].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(Content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(Content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(Content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[1].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(Content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[1].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(Content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[1].Get_Name() == "GhostRider_Icon")
                {

                }
            }
            else if (((SelectIcon)sender).Get_Name() == HeroSelect[2].Get_Name())
            {
                if (HeroSelect[2].Get_Name() == "Deadpool_Icon")
                {
                    var DeadpoolStatus = new SelectIcon(Content, IconHeros.Deadpool_Status);
                    DeadpoolStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = DeadpoolStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Ant-Man_Icon")
                {
                    var AntManStatus = new SelectIcon(Content, IconHeros.Ant_Man_Status);
                    AntManStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = AntManStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Hulk_Icon")
                {
                    var HulkStatus = new SelectIcon(Content, IconHeros.Hulk_Status);
                    HulkStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = HulkStatus;
                }
                else if (HeroSelect[2].Get_Name() == "Captain_Icon")
                {
                    var CaptainStatus = new SelectIcon(Content, IconHeros.Captain_Status);
                    CaptainStatus.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = CaptainStatus;
                }
                else if (HeroSelect[2].Get_Name() == "X-23_Icon")
                {
                    var X23Status = new SelectIcon(Content, IconHeros.X_23_Status);
                    X23Status.Position = new Vector2(Xposition[6], Yposition[6]);
                    HerosStatus[0] = X23Status;
                }
                else if (HeroSelect[2].Get_Name() == "GhostRider_Icon")
                {

                }
            }
        }

        private void Card_was_Clicked(object sender, EventArgs e)
        {
            numSelect = numSelect % 3;
            switch (((Card)sender).Get_Name())
            {
                case IconHeros.Deadpool_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconDeadpool = new SelectIcon(Content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconDeadpool = new SelectIcon(Content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconDeadpool = new SelectIcon(Content, IconHeros.Deadpool_Icon);
                            btnIconDeadpool.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconDeadpool;
                            btnIconDeadpool.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.AntMan_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconAntMan = new SelectIcon(Content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconAntMan = new SelectIcon(Content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconAntMan = new SelectIcon(Content, IconHeros.AntMan_Icon);
                            btnIconAntMan.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconAntMan;
                            btnIconAntMan.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.Hulk_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconHulk = new SelectIcon(Content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconHulk = new SelectIcon(Content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconHulk = new SelectIcon(Content, IconHeros.Hulk_Icon);
                            btnIconHulk.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconHulk;
                            btnIconHulk.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.Captain_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconCaptain = new SelectIcon(Content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconCaptain = new SelectIcon(Content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconCaptain = new SelectIcon(Content, IconHeros.Captain_Icon);
                            btnIconCaptain.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconCaptain;
                            btnIconCaptain.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.X23_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconX23 = new SelectIcon(Content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconX23 = new SelectIcon(Content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconX23 = new SelectIcon(Content, IconHeros.X23_Icon);
                            btnIconX23.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconX23;
                            btnIconX23.Click += Icon_was_Clicked;
                            numSelect++;
                            break;
                        }
                        break;
                    }
                case IconHeros.GhostRider_Card:
                    {
                        if (numSelect % 3 == 0)
                        {
                            var btnIconGhost = new SelectIcon(Content, IconHeros.GhostRider_Icon);
                            btnIconGhost.Position = new Vector2(Xposition[0], Yposition[0]);
                            HeroSelect[numSelect] = btnIconGhost;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 1)
                        {
                            var btnIconGhost = new SelectIcon(Content, IconHeros.GhostRider_Icon);
                            btnIconGhost.Position = new Vector2(Xposition[1], Yposition[1]);
                            HeroSelect[numSelect] = btnIconGhost;
                            numSelect++;
                            break;
                        }
                        else if (numSelect % 3 == 2)
                        {
                            var btnIconGhost = new SelectIcon(Content, IconHeros.GhostRider_Icon);
                            btnIconGhost.Position = new Vector2(Xposition[2], Yposition[2]);
                            HeroSelect[numSelect] = btnIconGhost;
                            numSelect++;
                            break;
                        }
                        break;
                    }
            }
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

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;


            foreach (var btnCard in cards)
                btnCard.Update(gameTime);

            foreach (var IconHeros in HeroSelect)
                IconHeros.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            Select_background.Draw(spriteBatch);
            Stetusbar.Draw(spriteBatch);

            foreach (var btnCard in cards)
                btnCard.Draw(gameTime, spriteBatch);

            foreach (var btnIcon in IconBackground)
                btnIcon.Draw(gameTime, spriteBatch);

            foreach (var HeroSelected1 in HeroSelect)
                HeroSelected1.Draw(gameTime, spriteBatch);

            foreach (var HeroStatused in HerosStatus)
                HeroStatused.Draw(gameTime, spriteBatch);

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