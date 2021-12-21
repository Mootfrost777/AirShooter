using AirShooter.Classes;
using AirShooter.Classes.Save;
using AirShooter.Classes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AirShooter
{
    public enum GameState
    {
        Menu, Game, Exit, GameOver, Info
    }

    public class Game1 : Game
    {
        private bool IsStarted = false;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static GameState gameState = GameState.Menu;

        private Random random = new Random();

        private Player player;
        private HUD hud = new HUD();
        private Space space;

        private List<Mine> asteroids = new List<Mine>();

        private List<Explosion> explosions = new List<Explosion>();

        private Explosion ex;

        private Enemy enemy;

        private Menu menu = new Menu();

        private GameOver gameOver;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 450;
        }

        protected override void Initialize()
        {
            player = new Player();

            space = new Space();

            ex = new Explosion(new Vector2(100, 100));

            gameOver = new GameOver();

            EnemyShip enemyShip = new EnemyShip(new Vector2(100, 100));
            enemy = enemyShip;

            menu.SetMenuPosition(new Vector2(400, 200));

            Container container = new Container();
            Save save = new Save(container);
            container = save.Deserialize();

            player.Health = container.Health;
            player.Score = container.Score;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player.LoadContent(Content);

            space.LoadContent(Content);

            enemy.LoadContent(Content);

            ex.LoadContent(Content);
            hud.LoadContent(Content);
            gameOver.LoadContent(Content);
            menu.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            switch (gameState)
            {
                case GameState.Menu:
                    space.Update();
                    menu.Update();
                    break;
                case GameState.Game:
                    UpdateGame(gameTime);

                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.Menu;
                    }
                    break;
                case GameState.Exit:
                    Exit();
                    break;
                case GameState.GameOver:
                    gameOver.Update();
                    if (gameOver.IsReset)
                    {
                        ResetGame();
                    }
                    break;
                case GameState.Info:

                default:
                    break;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Menu:
                    space.Draw(_spriteBatch);
                    menu.Draw(_spriteBatch);
                    break;
                case GameState.Game:
                    DrawGame();
                    break;
                case GameState.GameOver:
                    space.Draw(_spriteBatch);
                    gameOver.Draw(_spriteBatch);
                    break;
                default:
                    break;
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawGame()
        {
            space.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Draw(_spriteBatch);
            }

            DrawExplosions();

            enemy.Draw(_spriteBatch);

            hud.Draw(_spriteBatch);
        }

        private void UpdateGame(GameTime gameTime)
        {
            hud.Update(player.Score, player.Health);

            player.Update();

            enemy.Update(gameTime);

            space.Update();

            UpdateAsteroids();

            UpdateExplosions(gameTime);

            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Update();
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                Mine a = asteroids[i];

                for (int j = 0; j < player.BulletList.Count; j++)
                {
                    Laser b = player.BulletList[j];

                    if (a.BoundingBox.Intersects(b.BoundingBox))
                    {
                        Explosion e = new Explosion(new Vector2(a.BoundingBox.X,
                            a.BoundingBox.Y));
                        e.LoadContent(Content);
                        explosions.Add(e);

                        player.BulletList.Remove(b);
                        asteroids.Remove(a);

                        player.AddScores(1);

                        break;
                    }
                }
                if (a.BoundingBox.Intersects(player.BoundingBox))
                {
                    Explosion e = new Explosion(new Vector2(a.BoundingBox.X,
                            a.BoundingBox.Y));
                    e.LoadContent(Content);
                    explosions.Add(e);

                    asteroids.Remove(a);

                    player.GetDamage(1);

                    if (player.Health <= 0)
                    {
                        AirShooter.Game1.gameState = GameState.GameOver;
                    }
                }
            }
        }

        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = 0; i < explosions.Count; i++)
            {
                explosions[i].Update(gameTime);

                if (explosions[i].IsVisible == false)
                {
                    explosions.RemoveAt(i);
                    i--;
                }
            }
        }

        private void DrawExplosions()
        {
            foreach (var e in explosions)
            {
                e.Draw(_spriteBatch);
            }
        }
        private void ResetGame()
        {
            asteroids.Clear();
            player.BulletList.Clear();
            explosions.Clear();

            player = new Player();
            player.LoadContent(Content);
        }

        private void UpdateAsteroids()
        {
            int max_asteroids = 10;

            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].IsVisible == false)
                {
                    asteroids.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < max_asteroids - asteroids.Count; i++)
            {
                int x = random.Next(800, 1000);
                int y = random.Next(0, 420);
                Mine a = new Mine(new Vector2(x, y));
                a.LoadContent(Content);
                asteroids.Add(a);
            }
        }

    }
}
