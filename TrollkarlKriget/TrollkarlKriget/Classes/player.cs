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
		private int spriteNum = 3;
        private int acceleration = 1;
        private int maxSpeed = 15;
        private Vector2 curSpeed = new Vector2(0,0);
        private bool mAction;
        bool inAir = false;
        int jumpForce = 0;


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
		public void Update(player otherplayer,  World world, GameTime gameTime, Camera cam)
		{
			KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();
			if (keyboardState.IsKeyDown(Jump)){
					//TODO Add Jump funktion
				action = Actions.Jump;
				}
            position.X += curSpeed.X;

            if (Math.Abs(curSpeed.X) != maxSpeed)
            {
                if (keyboardState.IsKeyDown(Right))
                {

                    curSpeed.X = Math.Min(curSpeed.X + acceleration, maxSpeed);
                    action = Actions.Right;
                    mAction = true;
                }

                else if (keyboardState.IsKeyDown(Left))
                {
                    curSpeed.X = Math.Max(curSpeed.X - acceleration, -maxSpeed);
                    action = Actions.Left;
                    mAction = true;
                }


                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    //TODO Add kasta spells funktion
                    Random rand = new Random();
                    double num1 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) * MathHelper.Pi;
                    double num2 = Math.Sin(rand.NextDouble() * MathHelper.TwoPi) * MathHelper.Pi * 4;
                    Vector2 spellDirection = new Vector2(
                        mouseState.X - this.position.X - this.texture.Width/2 + world.cam.position.X,
                        mouseState.Y - this.position.Y - this.texture.Height / this.spriteNum / 2 + world.cam.position.Y);
                    spellDirection.Normalize();

                    world.worldParticles.Add(new particle(spellDirection*24 + new Vector2(this.position.X + this.texture.Width/2 , this.position.Y + this.texture.Height / this.spriteNum / 2 ), 
                        spellDirection*24 + this.curSpeed, world.firesprite,
                        gameTime.TotalGameTime.TotalMilliseconds, gameTime.TotalGameTime.TotalMilliseconds+1400, 
                        Color.White, Color.Transparent, 
                        1, 3, //Skala
                        1, 0.99f, // Luftmotstånd
                        new Vector2((float)0, (float)0), // Gravitation
                        new Vector2((float)0, (float)0), // Slutgravitation
                        num1, num2));
                    action = Actions.Spell;
                }


                if (keyboardState.IsKeyDown(Melee))
                {
                    //TODO Add slag funktion
                    action = Actions.Melee;
                }
            }

            if (!mAction)
            {
                curSpeed.X = curSpeed.X*10 / 11;
            }
            mAction = false;


           Rectangle myRect = new Rectangle(
               Convert.ToInt32(position.X),
               Convert.ToInt32(position.Y),
               texture.Width,
               (texture.Height / spriteNum));
           if (curSpeed.X == 0)
           {
               action = Actions.Still;
           }
           if (inAir)
           {
               position.Y += world.gravity - jumpForce;
           }
           this.checkCollision(cam, world); 


		}
		public void Draw(SpriteBatch spriteBatch, Camera cam)
		{
            Vector2 drawPos = position - cam.position;

			int spriteHeight = texture.Height / spriteNum; 
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

