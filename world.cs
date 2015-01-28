using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Trollkarlskriget
{
	public class world
	{
		public List <fyrkanter> tiles;
		public float Gravittion = 20;

		public world(List<fyrkanter> tiles)
		{
			this.tiles = tiles;
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var tile in tiles)
			{
				tile.Draw(spriteBatch);
			}
		}
	}
}

