using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class Mine
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private bool isVisible;

        private Rectangle boundingBox;

        public Rectangle BoundingBox { get { return boundingBox; } }

        public bool IsVisible { get { return isVisible; } }

        public Mine()
        {
            texture = null;
            position = new Vector2(200, 300);
            speed = 5;
            isVisible = true;
        }

        public Mine(Vector2 position)
        {
            texture = null;
            this.position = position;
            speed = 5;
            isVisible = true;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mine");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update()
        {
            position.X -= speed;

            if (position.X <= -100)
            {
                position.X = 1000;   
                isVisible = false;
            }

            boundingBox = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }
    }
}
