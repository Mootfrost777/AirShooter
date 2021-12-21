using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     // для ContentManager
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace AirShooter.Classes.UI
{
    class HUD
    {
        private Label lblScore;

        private Bar healthBar;
        

        private bool isVisible;

        public HUD()
        {
            lblScore = new Label("100", new Vector2(270, 2), Color.Blue);

            isVisible = true;

            healthBar = new Bar(null, new Vector2(10,10), Color.White, num_sections: 10, width_section: 25, 20);
        }

        public void LoadContent(ContentManager manager)
        {
            lblScore.LoadContent(manager);
            healthBar.LoadContent(manager);
        }

        public void Update(int score, int health)
        {
            lblScore.Text = score.ToString();

            healthBar.Update(health);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                lblScore.Draw(spriteBatch);
                healthBar.Draw(spriteBatch);
            }
        }
    }
}
