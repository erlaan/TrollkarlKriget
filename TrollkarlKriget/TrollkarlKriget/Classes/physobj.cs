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
    abstract class FysiskaObjekt
    {
        protected bool isAlive = true;

        public FysiskaObjekt(Texture2D texture, Vector2 position)
        {

        }
        public bool CheckCollision(FysiskaObjekt other)
        {

        }
    }
}
