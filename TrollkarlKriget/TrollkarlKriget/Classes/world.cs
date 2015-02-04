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
	public class world
	{
		public List <tiles> tiles;
		public float Gravittion = 20;

		public world(List<tiles> tiles)
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

