using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Wizards
{
    public class physobj : baseobj
    {
        private Actions action;

        bool inAir;
        int jumpForce = 0;
        public bool isAlive = true;
        player.Directions direction;
        public Vector2 curSpeed = new Vector2(0, 0);
        float speed;

        public physobj(Texture2D texture, Vector2 position, Vector2 speed) : base (texture, position)
        {
            this.curSpeed = speed;
            this.position = position;
            this.speed = 1;

        }
        public bool isCharactersColliding(physobj other)
        {
            Rectangle myRect = new Rectangle(
                Convert.ToInt32(position.X),
                Convert.ToInt32(position.Y),
                Convert.ToInt32(Width),
                Convert.ToInt32(Height/3));
            Rectangle otherRect = new Rectangle(
                Convert.ToInt32(other.position.X),
                Convert.ToInt32(other.position.Y),
                Convert.ToInt32(other.Width),
                Convert.ToInt32(other.Height/3));
            return myRect.Intersects(otherRect);
        }


        public bool Alive { get { return isAlive; } set { isAlive = value; } }

        public void checkCollision(Camera cam, World world)
        {
            
            if (inAir && action == Actions.Still)
            {
                action = Actions.Jump;
            }
            inAir = true;

            //Check collision
            int posX = (int)position.X/Settings.gridsize;
            int posY = (int)position.Y/Settings.gridsize;
            for (int x = Math.Max(0, posX-1); x < Math.Max(0, (int)Math.Ceiling((double)(posX + 2))); x++)
            {
                for (int y = Math.Max(0, posY); y < Math.Max(0, posY+3); y++)
                {
                    Tile tile = world.map[x, y];

                    if (tile.type != 0)
                    {
                        if (y == posY+3)
                        {
                            inAir = false;
                        }
                        else{
                            if (curSpeed.X > 0)
                            {
                                if (position.X + Settings.gridsize > x * Settings.gridsize)
                                {
                                    position.X--;
                                }
                            }
                            else if (curSpeed.X < 0)
                            {

                            }
                        }
                    }
                }
            }

            if (!inAir)
            {
                position.Y--;
                /*jumpForce = 0;

                action = Actions.Still;*/
            }

        }

    }
        
}