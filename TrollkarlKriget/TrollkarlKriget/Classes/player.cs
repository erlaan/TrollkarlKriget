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
	public class player
	{
		private Actions action;
		private Keys Jump;
		private Keys Right;
		private Keys Left;
		private Keys Spell;
		private Keys Melee;
		private Texture2D texture;
		public Vector2 position;
		private int spritenum = 3;
        private int acceleration = 1;
        private int maxspeed = 25;
        private float curspeed = 0;
        private bool mAction;


		public player (Texture2D texture, Vector2 position, Keys jump, Keys right, Keys left, Keys melee, Keys spell)
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
		public void Update(player otherplayer, World world)
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

           bool collided = false;

         /* foreach (var tile in world.map)
           {
               while (tile.isColliding(myRect))
               {
                   collided = true;
                   if (action == Actions.Jump || action == Actions.Jump)
                   {
                       position.Y--;
                       myRect = new Rectangle ( Convert.ToInt32(position.X),
                           Convert.ToInt32(position.Y), 
                           texture.Width, (texture.Height / spritenum));
                   }
               }
           }
           if (collided)
           {
               action = Actions.Still;
           } */ 



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

