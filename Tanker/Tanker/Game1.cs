using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NukeIt_Tanker.GameEntity;
using NukeIt_Tanker.CommManager;
using Tanker.AI;
using NukeIt_Tanker.Tokenizer;
using Tanker.GameEntity;

namespace Tanker
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDevice device;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D water, brick, stonewall, coin, lifepack, scorecard, tank_green, tank_blue, tank_yellow, tank_red, tank_orange, gameover, bullet;
        SpriteFont font;
        Vector2 vec0, vec1, vec2, vec3, vec4;
        int screenWidth;
        int screenHeight;
        int counter = 0;
        MainGrid active_grid;
        MessageHandler msghandler;
        MessageSender msgSender;

        // To update the UI
        Dictionary<string, Tank> tanks;
        Dictionary<Vector2, BrickWall> brickWalls;
        Dictionary<Vector2, StoneWall> stoneWalls;
        Dictionary<Vector2, Waters> waters;
        Dictionary<Vector2, Coin> coins;
        Dictionary<Vector2, LifePack> life_packs;
        Dictionary<string, Texture2D> playerLogo;
        Dictionary<string, Vector2> playerstat;
        // AI Object
        GameAI gameAI;
        // Time Keeper
        TimeKeeper timer;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            // The game terrain
            active_grid = new MainGrid();
            // Receive messages from server and update the grid
            msghandler = new MessageHandler(active_grid);
            // Send messages to the server and play the game
            msgSender = new MessageSender(msghandler);
            // Initiating the Game AI
            gameAI = new GameAI(active_grid, msgSender);
            // Initiating timer
            timer = new TimeKeeper(active_grid);
            Content.RootDirectory = "Content";
        }
        // For testing purposes only
        public Game1(bool test)
        {
            graphics = new GraphicsDeviceManager(this);
            // The game terrain
            active_grid = new MainGrid();
            // Receive messages from server and update the grid
            msghandler = new MessageHandler(active_grid);
            // Send messages to the server and play the game
            msgSender = new MessageSender(msghandler);
            Content.RootDirectory = "Content";
            MessageParser p1;
            MessageParser p2;
            MessageParser p3;
            MessageParser p4;
            MessageParser p5;
            MessageParser p6;
            MessageParser p7;
            p1 = new GlobalBroadCastHandler(active_grid);
            p2 = new AquirablesHandler(active_grid);
            p3 = new MovingAndShootingHandler(active_grid);
            p4 = new GameInidiationHandler(active_grid);
            p5 = new JoinMessageParser(active_grid);
            p6 = new JoinSuccessHandler(active_grid);
            p7 = new Finalizer(active_grid);
            p1.setNext(p2);
            p2.setNext(p3);
            p3.setNext(p4);
            p4.setNext(p5);
            p5.setNext(p6);
            p6.setNext(p7);
            timer = new TimeKeeper(active_grid);
            p1.handleMessage("I:P2:5,3;1,4;3,6;0,8;2,6;4,8;6,3;5,7;1,3:2,4;6,7;7,2;8,6;2,7;1,8;7,4;8,1;0,3;7,1:4,3;6,8;9,3;0,2;1,7;2,3;5,8;9,8;5,2;7,6#");
            p1.handleMessage("S:P0;0,0;0:P1;0,9;0:P2;9,0;0#");
            p1.handleMessage("C:1,0:5000:1747#");
            //p1.handleMessage("C:3,8:10000:1747#");
            p1.handleMessage("C:8,8:15000:1747#");
            p1.handleMessage("C:6,2:15000:1747#");
            p1.handleMessage("L:5,5:5000#");
            //p1.handleMessage("L:5,6:5000#");
            gameAI = new GameAI(active_grid, msgSender);


        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 700;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "NukeIt Tanker";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameover = Content.Load<Texture2D>("gameover");
            tank_green = Content.Load<Texture2D>("tank_green");
            tank_blue = Content.Load<Texture2D>("tank_blue");
            tank_orange = Content.Load<Texture2D>("tank_orange");
            tank_red = Content.Load<Texture2D>("tank_red");
            tank_yellow = Content.Load<Texture2D>("tank_yellow");
            texture = Content.Load<Texture2D>("background1");
            font = Content.Load<SpriteFont>("MyFont");
            scorecard = Content.Load<Texture2D>("scorecard");
            water = Content.Load<Texture2D>("water");
            brick = Content.Load<Texture2D>("brick");
            stonewall = Content.Load<Texture2D>("stonewall");
            coin = Content.Load<Texture2D>("Coin");
            lifepack = Content.Load<Texture2D>("lifepack");
            bullet = Content.Load<Texture2D>("rocket");
            device = graphics.GraphicsDevice;
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            // TODO: use this.Content to load your game content here
            vec0 = new Vector2(760, 325);
            vec1 = new Vector2(760, 350);
            vec2 = new Vector2(760, 375);
            vec3 = new Vector2(760, 400);
            vec4 = new Vector2(760, 425);
            playerstat = new Dictionary<string, Vector2>();
            playerstat.Add("P0", vec0);
            playerstat.Add("P1", vec1);
            playerstat.Add("P2", vec2);
            playerstat.Add("P3", vec3);
            playerstat.Add("P4", vec4);

            playerLogo = new Dictionary<string, Texture2D>();
            playerLogo.Add("P0", tank_green);
            playerLogo.Add("P1", tank_blue);
            playerLogo.Add("P2", tank_orange);
            playerLogo.Add("P3", tank_red);
            playerLogo.Add("P4", tank_yellow);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            ProcessKeyboard();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            DrawScenery();
            drawText();
            updateBricks();
            drawStones();
            drawWaters();
            drawCoins();
            drawLifePacks();
            updateTank();
            drawBullet();
            spriteBatch.End();
            // MathHelper.ToRadians(90)
            base.Draw(gameTime);
        }

        private void DrawScenery()
        {
            Rectangle screenrectangle = new Rectangle(700, 0, 300, 700);
            spriteBatch.Draw(scorecard, screenrectangle, Color.White);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; ++y)
                {
                    Rectangle rectangle = new Rectangle(y * 70, x * 70, 70, 70);
                    spriteBatch.Draw(texture, rectangle, Color.White);
                }

            }




        }

        private void drawText()
        {
            spriteBatch.DrawString(font, "PRESS ENTER TO JOIN THE GAME", new Vector2(720, 250), Color.Black);
            spriteBatch.DrawString(font, "Player ID     Points    Coins     Health", new Vector2(720, 300), Color.Black);


        }


        private void updateTank()
        {

            // update new tanks
            tanks = active_grid.Tanks;
            Stack<Tank> removable = new Stack<Tank>();
            try
            {
                foreach (Tank tk in tanks.Values.ToList<Tank>())
                {
                    if (tk.Health == 0 && tk.Player_name == active_grid.Playername)
                    {
                        Rectangle reclarge = new Rectangle(0, 0, 700, 700);
                        spriteBatch.Draw(gameover, reclarge, Color.White);
                        continue;

                    }
                    else if (tk.Health == 0)
                    {
                        //dropping their coins
                        Coin c = new Coin();
                        c.Location = tk.Location;
                        c.Value = tk.Coins;
                        c.Life_time = 999999999;
                        if (coins.ContainsKey(c.Location))
                        {
                            coins[c.Location].Value += c.Value;
                        }
                        else
                        {
                            coins.Add(tk.Location, c);
                        }
                        removable.Push(tk);
                        continue;
                    }
                    switch (tk.Direction)
                    {
                        case 0://north
                            spriteBatch.Draw(playerLogo[tk.Player_name], new Vector2(tk.Location.X * 70 + 35, tk.Location.Y * 70 + 35), null, Color.White, 0, new Vector2(35, 35), 1, SpriteEffects.None, 1);
                            spriteBatch.DrawString(font, tk.Player_name, new Vector2(tk.Location.X * 70 + 25, tk.Location.Y * 70 + 20), Color.White);

                            break;
                        case 1://east
                            spriteBatch.Draw(playerLogo[tk.Player_name], new Vector2(tk.Location.X * 70 + 35, tk.Location.Y * 70 + 35), null, Color.White, MathHelper.ToRadians(90), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                            spriteBatch.DrawString(font, tk.Player_name, new Vector2(tk.Location.X * 70 + 25, tk.Location.Y * 70 + 20), Color.White);
                            break;
                        case 2://south
                            spriteBatch.Draw(playerLogo[tk.Player_name], new Vector2(tk.Location.X * 70 + 35, tk.Location.Y * 70 + 35), null, Color.White, MathHelper.ToRadians(180), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                            spriteBatch.DrawString(font, tk.Player_name, new Vector2(tk.Location.X * 70 + 25, tk.Location.Y * 70 + 20), Color.White);
                            break;
                        case 3://west
                            spriteBatch.Draw(playerLogo[tk.Player_name], new Vector2(tk.Location.X * 70 + 35, tk.Location.Y * 70 + 35), null, Color.White, MathHelper.ToRadians(270), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                            spriteBatch.DrawString(font, tk.Player_name, new Vector2(tk.Location.X * 70 + 25, tk.Location.Y * 70 + 20), Color.White);
                            break;
                    }
                    if (tk.Player_name == active_grid.Playername)
                    {
                        spriteBatch.DrawString(font, tk.Player_name, playerstat[tk.Player_name], Color.DarkBlue);
                        spriteBatch.DrawString(font, tk.Points + "", new Vector2(playerstat[tk.Player_name].X + 60, playerstat[tk.Player_name].Y), Color.DarkBlue);
                        spriteBatch.DrawString(font, tk.Coins + "", new Vector2(playerstat[tk.Player_name].X + 130, playerstat[tk.Player_name].Y), Color.DarkBlue);
                        spriteBatch.DrawString(font, tk.Health + "%", new Vector2(playerstat[tk.Player_name].X + 200, playerstat[tk.Player_name].Y), Color.DarkBlue);

                    }
                    else
                    {
                        spriteBatch.DrawString(font, tk.Player_name, playerstat[tk.Player_name], Color.Black);
                        spriteBatch.DrawString(font, tk.Points + "", new Vector2(playerstat[tk.Player_name].X + 60, playerstat[tk.Player_name].Y), Color.Black);
                        spriteBatch.DrawString(font, tk.Coins + "", new Vector2(playerstat[tk.Player_name].X + 130, playerstat[tk.Player_name].Y), Color.Black);
                        spriteBatch.DrawString(font, tk.Health + "%", new Vector2(playerstat[tk.Player_name].X + 200, playerstat[tk.Player_name].Y), Color.Black);

                    }

                    // Remove coins if a tank collects them
                    if (coins.ContainsKey(tk.Location))
                    {
                        coins.Remove(tk.Location);
                    }
                    // Remove lifepack if a tank collects them
                    if (life_packs.ContainsKey(tk.Location))
                    {
                        life_packs.Remove(tk.Location);
                    }
                    // If the tank has shot
                    if (tk.Whether_shot)
                    {
                        active_grid.addBullet(new Bullet(tk.Direction, new Vector2(tk.Location.X * 70, tk.Location.Y * 70)));
                        tk.Whether_shot = false;
                    }
                }
            }
            catch (Exception)
            {

                //
            }
            while (removable.Count > 0)
            {
                tanks.Remove(removable.Pop().Player_name);
            }
        }

        //Draw bricks in the GUI
        private void updateBricks()
        {
            brickWalls = active_grid.BrickWalls;
            foreach (BrickWall br in brickWalls.Values.ToList<BrickWall>())
            {
                if (br.Damage == 4)
                {
                    brickWalls.Remove(br.Location);
                    continue;
                }
                Rectangle rc = new Rectangle((int)br.Location.X * 70, (int)br.Location.Y * 70, 70, 70);
                spriteBatch.Draw(brick, rc, Color.White);
                spriteBatch.DrawString(font, (100 - br.Damage * 25) + "", new Vector2((int)br.Location.X * 70 + 20, (int)br.Location.Y * 70 + 20), Color.White);
            }
        }

        // Draw stones in the GUI
        private void drawStones()
        {
            stoneWalls = active_grid.StoneWalls;
            foreach (StoneWall st in stoneWalls.Values.ToList<StoneWall>())
            {
                Rectangle rc = new Rectangle((int)st.Location.X * 70, (int)st.Location.Y * 70, 70, 70);
                spriteBatch.Draw(stonewall, rc, Color.White);
            }
        }

        // Draw water in the GUI
        private void drawWaters()
        {
            waters = active_grid.Waters;
            foreach (Waters wt in waters.Values.ToList<Waters>())
            {
                Rectangle rc = new Rectangle((int)wt.Location.X * 70, (int)wt.Location.Y * 70, 70, 70);
                spriteBatch.Draw(water, rc, Color.White);
            }
        }

        // Draw coins in the GUI
        private void drawCoins()
        {
            coins = active_grid.Coins;
            try
            {
                foreach (Coin cc in coins.Values.ToList<Coin>())
                {
                    Rectangle rc = new Rectangle((int)cc.Location.X * 70, (int)cc.Location.Y * 70, 70, 70);
                    spriteBatch.Draw(coin, rc, Color.White);
                    spriteBatch.DrawString(font, cc.Value + "$", new Vector2((int)cc.Location.X * 70 + 10, (int)cc.Location.Y * 70 + 25), Color.White);
                }
            }
            catch (Exception)
            {

                //
            }
        }

        // Drawing Life packs in the GUI
        private void drawLifePacks()
        {
            life_packs = active_grid.Life_packs;
            try
            {
                foreach (LifePack lp in life_packs.Values.ToList<LifePack>())
                {
                    Rectangle rc = new Rectangle((int)lp.Location.X * 70, (int)lp.Location.Y * 70, 70, 70);
                    spriteBatch.Draw(lifepack, rc, Color.White);
                }
            }
            catch (Exception)
            {

                //
            }
        }
        // Drawing bullets
        public void drawBullet()
        {
            // updates that happen in 1/60 th of a second are performed
            foreach (Bullet b in active_grid.getBullets().ToArray<Bullet>())
            {
                switch (b.Direction)
                {
                    case 0:
                        // North
                        b.PixelLocation = new Vector2(b.PixelLocation.X, b.PixelLocation.Y - 7);
                        break;
                    case 1:
                        // East
                        b.PixelLocation = new Vector2(b.PixelLocation.X + 7, b.PixelLocation.Y);
                        break;
                    case 2:
                        // South
                        b.PixelLocation = new Vector2(b.PixelLocation.X, b.PixelLocation.Y + 7);
                        break;
                    case 3:
                        // West
                        b.PixelLocation = new Vector2(b.PixelLocation.X - 7, b.PixelLocation.Y);
                        break;
                }
                // If there is a tank, stone, brick or index out remove the bullet
                if (b.PixelLocation.X > 70 * 9 || b.PixelLocation.Y > 70 * 9 || b.PixelLocation.X < 0 || b.PixelLocation.Y < 0)
                {
                    active_grid.removeBullet(b);
                    continue;
                }
                else
                {
                    foreach (Tank tk in active_grid.Tanks.Values.ToList<Tank>())
                    {
                        if (tk.Location.X == b.PixelLocation.X / 70 && tk.Location.Y == b.PixelLocation.Y / 70)
                        {
                            // Intercept with a tank
                            active_grid.removeBullet(b);
                            continue;
                        }
                    }
                    if (active_grid.StoneWalls.ContainsKey(new Vector2(b.PixelLocation.X / 70, b.PixelLocation.Y / 70)))
                    {
                        active_grid.removeBullet(b);
                    }
                    if (active_grid.BrickWalls.ContainsKey(new Vector2(b.PixelLocation.X / 70, b.PixelLocation.Y / 70)))
                    {
                        active_grid.removeBullet(b);
                    }
                }
            }

            foreach (Bullet b in active_grid.getBullets())
            {

                switch (b.Direction)
                {
                    case 0:
                        // North
                        spriteBatch.Draw(bullet, new Vector2(b.PixelLocation.X + 35, b.PixelLocation.Y + 35), null, Color.White, 0, new Vector2(35, 35), 1, SpriteEffects.None, 1);
                        break;
                    case 1:
                        // East
                        spriteBatch.Draw(bullet, new Vector2(b.PixelLocation.X + 35, b.PixelLocation.Y + 35), null, Color.White, MathHelper.ToRadians(90), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                        break;
                    case 2:
                        // South
                        spriteBatch.Draw(bullet, new Vector2(b.PixelLocation.X + 35, b.PixelLocation.Y + 35), null, Color.White, MathHelper.ToRadians(180), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                        break;
                    case 3:
                        // West
                        spriteBatch.Draw(bullet, new Vector2(b.PixelLocation.X + 35, b.PixelLocation.Y + 35), null, Color.White, MathHelper.ToRadians(270), new Vector2(35, 35), 1, SpriteEffects.None, 1);
                        break;
                }
            }
        }

        //takes keyboard input to join the game and move the tank
        private void ProcessKeyboard()
        {
            KeyboardState keybState = Keyboard.GetState();
            if (active_grid.GameStarted && lastPress + 1200 < CurrentTimeMillis())
            {
                //msgSender.left();
                gameAI.move();
                lastPress = CurrentTimeMillis();
            }
            /*
            if (keybState.IsKeyDown(Keys.Left))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    msgSender.left();
                    lastPress = CurrentTimeMillis();
                }
            }
            if (keybState.IsKeyDown(Keys.Right))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    msgSender.right();
                    lastPress = CurrentTimeMillis();
                }
            }
            if (keybState.IsKeyDown(Keys.Down))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    msgSender.down();
                    lastPress = CurrentTimeMillis();
                }
            }
            if (keybState.IsKeyDown(Keys.Up))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    msgSender.up();
                    lastPress = CurrentTimeMillis();
                }
            }
            if (keybState.IsKeyDown(Keys.Space))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    msgSender.shoot();
                    lastPress = CurrentTimeMillis();
                }
            }
            */



            if (keybState.IsKeyDown(Keys.Enter))
            {
                if (lastPress + 1000 < CurrentTimeMillis())
                {
                    if (counter == 0)
                    {
                        ++counter;
                        msgSender.join();
                        lastPress = CurrentTimeMillis();

                    }
                }

            }/**/


        }

        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static long lastPress = 0;
        private static long lastUpdate = 0;
        private static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
    }
}
