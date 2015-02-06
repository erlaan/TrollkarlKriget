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
	public class player : physobj
	{
		private Actions action;
		private Keys Jump;
		private Keys Right;
		private Keys Left;
		private Keys Spell;
		private Keys Melee;
		private int spritenum = 3;
        private int acceleration = 1;
        private int maxspeed = 15;
        private float curspeed = 0;
        private bool mAction;


		public player (Texture2D texture, Vector2 position, Keys jump, Keys right, Keys left, Keys melee, Keys spell)
            :  base (texture, position)
		{
			this.position = position;
			this.texture = texture;
			this.Jump = jump;
			this.Right = right;
			this.Left = left;
			this.Spell = spell;
			this.Melee = melee;
            this.mAction = false;
			action = Actions.Still;
		}
		public void Update(player otherplayer,  World world, GameTime gameTime)
		{
			KeyboardState newState = Keyboard.GetState (); 
			if (newState.IsKeyDown(Jump)){
					//TODO Add Jump funktion
				action = Actions.Jump;
				}
            position.X += curspeed;

            if (Math.Abs(curspeed) != maxspeed)
            {
                if (newState.IsKeyDown(Right))
                {

                    curspeed = Math.Min(curspeed + acceleration, maxspeed);
                    action = Actions.Right;
                    mAction = true;
                }

                else if (newState.IsKeyDown(Left))
                {
                    curspeed = Math.Max(curspeed - acceleration, -maxspeed);
                    action = Actions.Left;
                    mAction = true;
                }


                if (newState.IsKeyDown(Spell))
                {
                    //TODO Add kasta spells funktion
                    Random rand = new Random();
                    double divisor = 16;
                    double num = Math.Sin(rand.NextDouble()*MathHelper.TwoPi)/divisor;
                    double num2 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) / divisor;
                    double num3 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) / divisor; 
                    double num4 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) / divisor;
                    double num5 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) * MathHelper.Pi;
                    double num6 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) * MathHelper.Pi * 4;

                    world.worldParticles.Add(new particle(this.position + new Vector2(100,175), new Vector2(this.curspeed, 0), world.firesprite,
                        gameTime.TotalGameTime.TotalMilliseconds, gameTime.TotalGameTime.TotalMilliseconds+3500, 
                        Color.White, Color.Transparent, 
                        1, 1, //Skala
                        1, 0, // Luftmotstånd
                        new Vector2((float)num, (float)num2), // Gravitation
                        new Vector2((float)num3, (float)num4), // Slutgravitation
                        num5, num6));
                    action = Actions.Spell;
                }

                if (newState.IsKeyDown(Melee))
                {
                    //TODO Add slag funktion
                    action = Actions.Melee;
                }
            }

            if (!mAction)
            {
                curspeed = curspeed*10 / 11;
            }
            mAction = false;


           Rectangle myRect = new Rectangle(
               Convert.ToInt32(position.X),
               Convert.ToInt32(position.Y),
               texture.Width,
               (texture.Height / spritenum));
           if (curspeed == 0)
           {
               action = Actions.Still;
           }


		}
		public void Draw(SpriteBatch spriteBatch, Camera cam)
		{
            Vector2 drawPos = position - cam.position;

			int spriteHeight = texture.Height / spritenum; 
			switch (action)
			{
			case (Actions.Still):
				spriteBatch.Draw(texture, drawPos, new Rectangle(0,0,
					texture.Width, spriteHeight), Color.White);
				break;

			case (Actions.Jump):
				spriteBatch.Draw(texture, drawPos, new Rectangle(0,spriteHeight*2,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Melee):
				spriteBatch.Draw(texture, drawPos, new Rectangle(0, spriteHeight,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Spell):
				spriteBatch.Draw(texture, drawPos, new Rectangle(0, spriteHeight*2,
					texture.Width, spriteHeight), Color.White);

				break;

			case (Actions.Right):
				spriteBatch.Draw (texture, drawPos, new Rectangle (0, spriteHeight * 1,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Left):
				spriteBatch.Draw (texture, drawPos, new Rectangle (0, spriteHeight * 1,
					texture.Width, spriteHeight), Color.White);
                break;
			}
		}
	}
}

