using System;
using System.Collections.Generic;
using System.Text;

namespace AirShooter.Classes.Save
{

    [Serializable]
    public class Container
    {
        public int Score { get; set; }
        public int Health { get; set; }

        public Container(Player player)
        {
            Score = player.Score;
            Health = player.Health;
        }

        public Container() 
        {
            Score = 0;
            Health = 0;
        }
    }
}
