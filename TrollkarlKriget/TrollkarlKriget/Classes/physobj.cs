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
   class physobj : baseobj
    {

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
        
    }
}
