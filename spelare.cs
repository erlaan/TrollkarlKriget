﻿using System;
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

namespace Trollkarlskriget
{
	public class spelare
	{
		private Actions action;
		private Keys Jump;
		private Keys Right;
		private Keys Left;
		private Keys Trollformel;
		private Keys Slash;
		private Texture2D texture;
		private Vector2 position;


		public spelare (Texture2D texture, Vector2 position, Keys jump, Keys right, Keys left, Keys slash, Keys trollforemel)
		{
			this.position = position;
			this.texture = texture;
			this.Jump = jump;
			this.Right = right;
			this.Left = left;
			this.Trollformel = trollformel;
			this.Slash = slash;
			action = Actions.still;
		}
		public void Update(spelare otherspelare, world world)
		{
			KeyboardState newState = Keyboard.GetState (); 
			if (newState.IsKeyDown(Jump)){
					//TODO Add Jump funktion
				}

			if (newState.IsKeyDown (Right)) {

				position.X += 5;
			}

			if (newState.IsKeyDown (Left)) {

				position.X -= 5;
			}

			if (newState.IsKeyDown (Trollformel)) {
				//TODO Add kasta spells funktion
			}

			if (newState.IsKeyDown (Slash)) {
				//TODO Add slag funktion
			}
		}
		public void Draw(SpriteBatch spritebatch)
		{
			//TODO Lägga till en ritfunktioner
		}
	}
}

