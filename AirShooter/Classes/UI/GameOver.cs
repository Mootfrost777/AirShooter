using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace AirShooter.Classes.UI
{
    class GameOver
    {
        private Texture2D texture;
        private Vector2 position;
        private bool isReset = false;

        public bool IsReset
        {
            get { return isReset; }
        }

        public GameOver()
        {
            position = new Vector2(0, 0);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("endMenu");
        }

        public void Update()
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Thread.Sleep(100);
                Game1.gameState = GameState.Menu;
                isReset = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
