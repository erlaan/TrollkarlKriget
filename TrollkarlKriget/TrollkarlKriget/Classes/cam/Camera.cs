using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Wizards
{
    public class Camera
    {
        public int width;
        public int height;

        public List<Tile> visibleTiles;

        public Vector2 position;

        public Camera()
        {
            position = new Vector2(0, 0);
            width = 20;
            height = 10;

            visibleTiles = new List<Tile>();

        }

        public void Update(GameTime gameTime, player player)
        {
            
            position.X = player.position.X - ((width * 64) / 2);
            position.Y = player.position.Y -((height * 64) - 100);
        }
    }
}
