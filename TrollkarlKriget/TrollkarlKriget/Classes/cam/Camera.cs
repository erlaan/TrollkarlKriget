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
        Vector2 posX;
        float xSpeed;
        float ySpeed;

        public Vector2 position;

        public Camera()
        {
            position = new Vector2(0, 0);
            width = 12;
            height = 6;

            xSpeed = 0;
            ySpeed = 0;

        }

        public void Update(GameTime gameTime, player player)
        {
            
            position.X = player.position.X - 200;
            position.Y = player.position.Y - 200;
        }
    }
}
