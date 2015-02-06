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
    public abstract class baseobj
    {
        protected Texture2D texture;
        public Vector2 position;

        public baseobj(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position.X = position.X;
            this.position.Y = position.Y;

        }

        public Vector2 GetPos { get { return position; } }
        public Vector2 SetPos { set { position = value; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }


    }
}
