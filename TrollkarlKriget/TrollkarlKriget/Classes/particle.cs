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
    public class particle
    {
        private Vector2 pos;
        private Vector2 speed;
        private Vector2 size;
        private Texture2D texture;
        private TimeSpan initTime;
        private TimeSpan endTime;
        private TimeSpan timeLength;

        private Color color;

        private Vector2 initResistance;
        private Vector2 endResistance;
        private Vector2 initGravity;
        private Vector2 endGravity;
        private Vector2 initSize;
        private Vector2 endSize;

        private Color initColor;
        private Color endColor;

        public particle(Vector2 pos, Vector2 speed, Texture2D texture, TimeSpan initTime, TimeSpan endTime, Color color, Vector2 initSize, Vector2 endSize)
        {
            this.pos = pos;
            this.speed = speed;
            this.texture = texture;
            this.initTime = initTime;
            this.endTime = endTime;
            this.timeLength = endTime - initTime;
            this.color = color;
            this.initSize = initSize;
            this.endSize = endSize;
        }

        public void Update(world world, GameTime gametime)
        {
            this.pos += speed;

            float tempTime = (float)((endTime.TotalMilliseconds - gametime.TotalGameTime.TotalMilliseconds) / timeLength.Milliseconds); 
            // Returnerar en float som går från 1 till 0 beroende på tidpunkten som den räknas ut; Används för alla init/end variabler i Update.

            this.speed.X += initGravity.X * tempTime + endGravity.X * (1 - tempTime);
            this.speed.Y += initGravity.Y * tempTime + endGravity.Y * (1 - tempTime); 
            // Räkna ut gravitationens påverkan på hastigheten

            this.speed.X *= initResistance.X * tempTime + endResistance.X * (1 - tempTime);
            this.speed.Y *= initResistance.Y * tempTime + endResistance.Y * (1 - tempTime); 
            //Räkna ut luftresistansens påverkan på hastigheten


            this.color.R *= (byte)((float)initColor.R * tempTime + (float)endColor.R * (1 - tempTime)); 
            this.color.G *= (byte)((float)initColor.G * tempTime + (float)endColor.G * (1 - tempTime));
            this.color.B *= (byte)((float)initColor.B * tempTime + (float)endColor.B * (1 - tempTime));
            this.color.A *= (byte)((float)initColor.A * tempTime + (float)endColor.A * (1 - tempTime)); 
            //Räkna ut tidens påverkan på färgen

            this.size.X = initSize.X * tempTime + endSize.X * (1 - tempTime);
            this.size.Y = initSize.Y * tempTime + endSize.Y * (1 - tempTime); 
            // Räkna ut tidens påverkan på storleken
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, new Rectangle(-(int)size.X / 2, -(int)size.Y / 2,
    (int)size.X / 2, (int)size.Y / 2), color);
        }
    }
}
