using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;     
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AirShooter.Classes
{
    class Weapon
    {
        protected List<Laser> bulletList = new List<Laser>();

        protected Texture2D texture;
        protected int bulletSpeed;
        private Vector2 position;
        private bool isVisible;
        private int bulletDamage;
        protected int delay;

    }
}
