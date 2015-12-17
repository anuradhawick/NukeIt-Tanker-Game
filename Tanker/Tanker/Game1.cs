using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using NukeIt_Tanker.GameEntity;
using NukeIt_Tanker.CommManager;

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
        Texture2D scorecard;
        Texture2D[,] texture;
        Texture2D water;
        Texture2D brick;
        Texture2D stonewall;
        Texture2D coin;
        Texture2D lifepack;
        SpriteFont font;
        int screenWidth;
        int screenHeight;
        MainGrid active_grid;
        MessageHandler msghandler;
        MessageSender msgSender;
        public Game1()
        {
            active_grid = new MainGrid();
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
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
            texture = new Texture2D[10, 10];
            for (int i=0;i<10;++i) {
                for (int y=0;y<10;++y) {
                    texture[i, y] = Content.Load<Texture2D>("background1");
                }
            }
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("MyFont");
            scorecard = Content.Load<Texture2D>("scorecard");
            water = Content.Load<Texture2D>("water");
            brick = Content.Load<Texture2D>("brick");
            stonewall = Content.Load<Texture2D>("stonewall");
            coin = Content.Load<Texture2D>("Coin");
            lifepack = Content.Load<Texture2D>("lifepack");
            device = graphics.GraphicsDevice;
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;
            // TODO: use this.Content to load your game content here
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
            spriteBatch.End();

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
                    spriteBatch.Draw(texture[x, y], rectangle, Color.White);
                }

            }
            Rectangle coinrectangle = new Rectangle(630, 630, 70, 70);
            spriteBatch.Draw(coin,coinrectangle, Color.White);
        //    texture[0, 1]= water;
        //    texture[1, 1] = brick;
        //    texture[0, 2] = stonewall;
          //  texture[0, 3] = coin;
        //    texture[0, 4] = lifepack;

        }

        private void drawText() {
            spriteBatch.DrawString(font, "PLayer ID     Points     Coins", new Vector2(740,300), Color.Black);
        }
    }
}
