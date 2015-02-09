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
        protected bool isAlive = true;

        public physobj(Texture2D texture, Vector2 position) : base (texture, position)
        {

        }
        public bool isColliding(Rectangle otherRect)
        {
            Rectangle myRect = new Rectangle(
                Convert.ToInt32(position.X),
                Convert.ToInt32(position.Y),
                Convert.ToInt32(Width),
                Convert.ToInt32(Height) );
            return myRect.Intersects(otherRect);
        }


        public bool Alive { get { return isAlive; } set { isAlive = value; } }

        public void checkCollision(Camera cam, World world)
        {
            Rectangle myRect = new Rectangle(
                Convert.ToInt32(position.X + (texture.Width / 3)),
                Convert.ToInt32(position.Y + (texture.Height / 3) - 1),
                texture.Width / 2,
                1);

            bool checkIfOnGround = false;
            if (inAir && action == Actions.Still)
            {
                action = Actions.Jump;
            }
            inAir = true;

            foreach (var tile in cam.visibleTiles) {

                /*while(tile.isColliding(myRect))
                {
            
                    checkIfOnGround = true;

                    position.Y--;

                    myRect = new Rectangle (
                        Convert.ToInt32 (position.X + (texture.Width/3)),
                        Convert.ToInt32 (position.Y + (texture.Height/3)-1),
                        texture.Width / 2,
                        1);
                }*/
            }

            if (checkIfOnGround || action == Actions.Still) {
                jumpForce = 0;

                action = Actions.Still;

            }else {
                inAir = true;
            }





        }
        
    }
}
