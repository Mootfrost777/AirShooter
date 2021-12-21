using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class Enemy
    {
        protected Texture2D texture;
        private Vector2 position;
        protected int speed;
        private bool isVisible;
        private Rectangle boundingBox;
        private Rectangle destinationRectangle;
        protected float rotation;

        private Weapon weapon;    

        public Enemy(Vector2 position)
        {
            this.position = position;
            speed = 5;
            texture = null;
            rotation = 0;
        }

        public virtual void LoadContent(ContentManager content)
        {
            destinationRectangle = new Rectangle((int)position.X,
                (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(destinationRectangle.Width / 2 - 30,
                destinationRectangle.Height / 2 - 10);

            spriteBatch.Draw(texture, destinationRectangle, null, Color.White,
                rotation, origin, SpriteEffects.None, 1);
        }

        public virtual void Update(GameTime gameTime)
        {
            position.Y += speed;

            if (position.Y >= 700)   
            {
                isVisible = false;
            }
        }
    }
}
