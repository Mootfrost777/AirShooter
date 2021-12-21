using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AirShooter.Classes.UI
{
    class Bar
    {
        private Texture2D texture;
        private Vector2 position;
        private Color color;
        private int size;                     
        private int width;                    
        private Rectangle sourceRectangle;    
        private int height;
        private int width_section;            

        public Bar(Texture2D texture, Vector2 position, Color color,
            int num_sections, int width_section, int height)
        {
            this.texture = texture;
            this.position = position;
            this.color = color;
            this.size = num_sections;
            this.width = width_section * num_sections;
            this.height = height;
            this.width_section = width_section;             
        }


        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("box");
        }

        public void Update(int num_scores)
        {
            this.width = this.width_section * num_scores;
            size = num_scores;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X,
                (int)position.Y, width, height);

            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
