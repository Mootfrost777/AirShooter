using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class Space
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;
        private int speed;

        public Space()
        {
            texture = null;
            position1 = new Vector2(0, 0);
            position2 = new Vector2(300, 0);
            speed = 1;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("mainbackground");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }

        public void Update()
        {
            position1.X -= speed;
            position2.X -= speed;

            if (position1.X <= 0)
            {
                position1.X = 800;
                position2.X = 0;
            }
        }
    }
}
