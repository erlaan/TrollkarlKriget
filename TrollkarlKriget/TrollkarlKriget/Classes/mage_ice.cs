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
	public class Hydromancer : player
	{
		public Hydromancer(Texture2D texture, Vector2 position, Vector2 speed, Keys jump, Keys right, Keys left, Keys melee, Keys spell)
			:base(texture, position, speed, jump,right,left,melee,spell)
		{
		}
	}
}

