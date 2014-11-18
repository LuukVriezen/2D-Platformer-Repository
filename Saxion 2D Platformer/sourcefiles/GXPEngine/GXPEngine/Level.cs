using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Level : GameObject
    {
        Player player;
        public Level()
        {
            player = new Player();
            AddChild(player);
        }
    }
}
