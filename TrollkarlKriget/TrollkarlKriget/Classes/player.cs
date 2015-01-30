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
		private Vector2 position;
		private int spritenum = 6;


		public player (Texture2D texture, Vector2 position, Keys jump, Keys right, Keys left, Keys melee, Keys spell)
		{
			this.position = position;
			this.texture = texture;
			this.Jump = jump;
			this.Right = right;
			this.Left = left;
			this.Spell = spell;
			this.Melee = melee;
			action = Actions.Still;
		}
		public void Update(player otherplayer, world world)
		{
			KeyboardState newState = Keyboard.GetState (); 
			if (newState.IsKeyDown(Jump)){
					//TODO Add Jump funktion
				action = Actions.Jump;
				}

			if (newState.IsKeyDown (Right)) {

				position.X += 5;
				action = Actions.Springahöger;
			}

			if (newState.IsKeyDown (Left)) {

				position.X -= 5;
				action = Actions.Springavänster;
			}

			if (newState.IsKeyDown (Trollformel)) {
				//TODO Add kasta spells funktion
				action = Actions.Kastamagi;
			}

			if (newState.IsKeyDown (Slash)) {
				//TODO Add slag funktion
				action = Actions.Slash;
			} 


			Rectangle myRect = new Rectangle(
				Convert.ToInt32(position.X),
				Convert.ToInt32(position.Y),
				texture.Width,
				(texture.Height / hurmangasprite));

			foreach (var tile in world.tiles)
			{
				while (tile.isColliding(myRect))
				{
					collided = true;
					if (action == Actions.Jumping || action == Actions.Jumping)
					{
						position.Y--;
						myRect = new Rectangle ( Convert.ToInt32(position.X),
							Convert.ToInt32(position.Y), 
							texture.Width, (texture.Height / hurmangasprite));
					}
				}
			}
		if (collided)
		{
			action = Actions.Still;
		}



		}
		public void Draw(SpriteBatch spriteBatch)
		{

			int spriteHeight = texture.Height / 3; 
			switch (action)
			{
			case (Actions.Still):
				spriteBatch.Draw(texture, position, new Rectangle(0,0,
					texture.Width, spriteHeight), Color.White);
				break;

			case (Actions.Jump):
				spriteBatch.Draw(texture, position, new Rectangle(0,spriteHeight*2,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Slash):
				spriteBatch.Draw(texture, position, new Rectangle(0, spriteHeight,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Kastamagi):
				spriteBatch.Draw(texture, position, new Rectangle(0, spriteHeight*3,
					texture.Width, spriteHeight), Color.White);

				break;

			case (Actions.Springahöger):
				spriteBatch.Draw (texture, position, new Rectangle (0, spriteHeight * 4,
					texture.Width, spriteHeight), Color.White);

				break;
			case (Actions.Springavänster):
				spriteBatch.Draw (texture, position, new Rectangle (0, spriteHeight * 5,
					texture.Width, spriteHeight), Color.White);
			}
		}
	}
}

