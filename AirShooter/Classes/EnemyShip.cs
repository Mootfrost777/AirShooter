using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class EnemyShip : Enemy
    {
        public EnemyShip() : base(Vector2.Zero)
        {
            speed = 6;
        }

        public EnemyShip(Vector2 position) : base(position)
        {
            speed = 6;
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("player");

            base.LoadContent(content);
        }

        public override void Update(GameTime gameTime)
        {
            rotation = 3.14f;
        }
    }
}
