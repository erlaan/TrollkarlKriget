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

        public void Update(Vector2 playerPos)
        {

            position.X = playerPos.X - (((float)width * (float)Settings.gridsize) / 2.0f);
            position.Y = playerPos.Y - ((((float)height * (float)Settings.gridsize) / 2.0f) + 100.0f);
        }
    }
}
