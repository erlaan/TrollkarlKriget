using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Trollkarlkriget
{

    abstract class MovingObject
    {
        public MovingObject(Texture2D texture, Vector2 position, float speed)
        { }
    }

    abstract class PhysicalObject : MovingObject
    {
        protected bool isAlive = true;

        public PhysicalObject(Texture2D texture, Vector2 position, float speed) : base(texture, position, speed)
        {

        }
        public bool CheckCollision(FysiskaObjekt other)
        {
        }
        public bool IsAlive 
        { 
            get { return isAlive; } 
            set { isAlive = value; } 
        }
    }
}
