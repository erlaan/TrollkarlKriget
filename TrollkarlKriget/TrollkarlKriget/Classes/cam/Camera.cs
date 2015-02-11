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
            width = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.8);
            height = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.8);

            visibleTiles = new List<Tile>();

        }

        public void Update(Vector2 playerPos)
        {

            position.X = (float)Math.Round(playerPos.X - (width / 2) + 32);
            position.Y = (float)Math.Round(playerPos.Y - (height / 2) + 32);
        }
    }
}
