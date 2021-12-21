using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;    
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace AirShooter.Classes
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;

        private int score;
        private int health;

        private Texture2D textureBullet;
        private float bulletDelay;        

        private List<Laser> bulletList = new List<Laser>();

        public Rectangle BoundingBox { get; set; }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public List<Laser> BulletList
        {
            get { return bulletList; }
        }

        public Player()
        {
            score = 0;
            health = 10;

            position = new Vector2(100, 200);
            texture = null;
            speed = 6;

            bulletDelay = 10;  
        }

        public void AddScores(int score)
        {
            if (score >= 0)     
            {
                Score += score;
            }
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");

           textureBullet = manager.Load<Texture2D>("laser");
        }

        public void Draw(SpriteBatch brush)
        {
            brush.Draw(texture, position, Color.White);

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(brush);
            }
        }

        public void Update()
        {
            BoundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Space))
            {
                PlayerShoot();
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }

            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.Y <= 0)
            {
                position.Y = 0;
            }
            if (position.X + texture.Width >= 800)
            {
                position.X = 800 - texture.Width;
            }
            if (position.Y + texture.Height >= 450)
            {
                position.Y = 450 - texture.Height;
            }

            UpdateBullets();
        }

        public void UpdateBullets()
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update();
            }


            for (int i = 0; i < bulletList.Count; i++)
            {
                if (bulletList[i].IsVisible == false)
                {
                    bulletList.RemoveAt(i);   
                    i--;
                }
            }
        }

        public void PlayerShoot()
        {
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }

            if (bulletDelay <= 0)
            {
                if (bulletList.Count < 20) 
                {
                    Vector2 bullet_pos = new Vector2(position.X + texture.Width - 30, position.Y + texture.Height / 2 - 7);
                    Laser bullet = new Laser(textureBullet, bullet_pos);
                    bullet.Speed = 10;
                    bulletList.Add(bullet);  
                }
            }

            if (bulletDelay == 0)
            {
                bulletDelay = 10;
            }
        }
    }
}
