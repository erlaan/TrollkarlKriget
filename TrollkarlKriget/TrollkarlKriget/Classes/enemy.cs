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
    public class enemy : physobj
    {
        private int spriteNum = 3;
        private int spriteHeight;
        int health;
        public enemy(Texture2D texture, Vector2 position)
            : base(texture, position)
        { }
        public void Update(World world)
        {
            position.Y += world.gravity;
        }
        public void Draw(SpriteBatch spriteBatch, Camera cam)
        {
            Vector2 drawPos = position - cam.position;
            spriteHeight = texture.Height / spriteNum;
            spriteBatch.Draw(texture, drawPos, new Rectangle(0, 0,
                    texture.Width, spriteHeight), Color.White);

        }
    }
}
