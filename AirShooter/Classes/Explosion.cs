using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class Explosion
    {
        // Поля
        private Texture2D texture;
        private Vector2 position;
        private float timer;       
        private float interval;    
        private Vector2 origin;    
        private int currentFrame;  
        private int spriteWidth;   
        private int spriteHeight;  
        private Rectangle sourceRectangle;   
        private bool isVisible;

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
        }

        public Explosion(Vector2 position)
        {
            this.position = position;
            texture = null;
            timer = 0;
            interval = 20;
            currentFrame = 1;
            spriteWidth = 117;
            spriteHeight = 117;
            isVisible = true;
            origin = Vector2.Zero;

        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("explosion3");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White,
                0, origin, 1, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            timer += t;

            if (timer > interval)  
            {
                currentFrame++;
                timer = 0;
            }

            if (currentFrame == 17)
            {
                currentFrame = 0;

                isVisible = false;
            }

            sourceRectangle = new Rectangle(spriteWidth * currentFrame, 0, spriteWidth, spriteHeight);

            System.Diagnostics.Debug.WriteLine(timer);
        }

    }
}
