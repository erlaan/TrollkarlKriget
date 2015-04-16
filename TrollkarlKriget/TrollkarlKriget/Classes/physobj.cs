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

        public physobj(Texture2D texture, Vector2 position, Vector2 speed)
            : base(texture, position)
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
                Convert.ToInt32(Height / 3));
            Rectangle otherRect = new Rectangle(
                Convert.ToInt32(other.position.X),
                Convert.ToInt32(other.position.Y),
                Convert.ToInt32(other.Width),
                Convert.ToInt32(other.Height / 3));
            return myRect.Intersects(otherRect);
        }


        public bool Alive { get { return isAlive; } set { isAlive = value; } }

        public void checkCollision(Camera cam, World world)
        {
            Rectangle playerRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height/3);
            foreach (Tile tile in cam.visibleTiles) 
            {
                Rectangle tileRect = new Rectangle((int)tile.position.X, (int)tile.position.Y, Settings.gridsize, Settings.gridsize);
                if (tile.type!=0 && playerRect.Intersects(tileRect)){
                    switch(Math.Abs(position.X-tile.position.X)>Math.Abs(position.Y-tile.position.Y)){
                        case (true):
                            if (curSpeed.Y > 0)
                            {
                                position.Y -= position.Y - tile.position.Y;
                            }
                            else
                            {
                                position.Y += position.Y - tile.position.Y;
                            }
                            break;
                        case (false):
                            if (curSpeed.X < 0)
                            {
                                position.X += position.X - tile.position.X;
                            }
                            else
                            {
                                position.X -= position.X - tile.position.X;
                            }
                            break;
                    }
                playerRect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height/3);

                }
            }
            if (inAir && action == Actions.Still)
            {
                action = Actions.Jump;
            }
            inAir = true;

            //Check collision
            /*int posX = (int)(position.X / Settings.gridsize);
            int posY = (int)(position.Y / Settings.gridsize);
            for (int x = Math.Max(0, posX); x < Math.Min(world.worldSize, (int)Math.Ceiling((double)(posX + 2))); x++)
            {
                for (int y = Math.Max(0, posY); y < Math.Min(world.worldSize, posY + 3); y++)
                {
                    Tile tile = world.map[x, y];

                    if (tile.type != 0)
                    {

                        if (position.X > posX * Settings.gridsize && position.X - texture.Width < posX * Settings.gridsize &&
                            position.Y + texture.Height / 3 > posY * Settings.gridsize && curSpeed.X < 0)
                        {
                            position.X++;
                            curSpeed.X = 0;
                        }
                        else if (position.X < posX * Settings.gridsize && position.X + texture.Width > posX * Settings.gridsize &&
                            position.Y + texture.Height / 3 > posY * Settings.gridsize && curSpeed.X > 0)
                        {
                            position.X--;
                            curSpeed.X = 0;
                        }
                    }
                }
            }*/

            if (!inAir)
            {
                position.Y--;
                /*jumpForce = 0;

                action = Actions.Still;*/
            }

        }

    }

}