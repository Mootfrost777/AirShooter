using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    public class Laser
    {
        private Texture2D texture;
        private Vector2 position;
        private int speed;
        private bool isVisible;
        private Rectangle rectangle;
        private Vector2 size;           

        private Rectangle boundingBox;  

        public Rectangle BoundingBox { get { return boundingBox; } }

        public int Speed
        {
            set { speed = value; }
        }

        public bool IsVisible
        {
            get { return isVisible; }
        }

        public Laser(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            speed = 0;
            isVisible = true;
            this.position = position;

            size = new Vector2(20, 20);

            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public Laser() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public void Update()
        {

            position.X += speed;
            rectangle = new Rectangle((int)position.X + 30, (int)position.Y + texture.Height / 2, (int)size.X, (int)size.Y);

            if (position.X >= 850)
            {
                isVisible = false;
            }

            boundingBox = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);
        }
    }
}
