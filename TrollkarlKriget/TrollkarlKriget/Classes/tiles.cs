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
	public class tiles
	{
		private Vector2 position;
		private Texture2D texture;

		public tiles(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
		}

		public void Update()
		{


		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}

		public bool isColliding(Rectangle otherRect)
		{

			Rectangle myRect = new Rectangle(
				Convert.ToInt32(this.position.X),
				Convert.ToInt32(this.position.Y),
				texture.Width,
				texture.Height);

			if (otherRect.Intersects(myRect))
			{
				return true;
			}
			return false;
		}

	}
}

