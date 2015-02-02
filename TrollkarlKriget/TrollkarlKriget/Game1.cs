#region Using Statements
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


#endregion

namespace Wizards
{

	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
        public player p1; // Player 1
        world world; //The map

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = false;		
		}


		protected override void Initialize ()
		{
			// TODO: Add your initialization logic here
			base.Initialize ();
				
		}


		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);

            p1 = new player(Content.Load<Texture2D>("images/players/sprite"),
            new Vector2(100, 100),
            Keys.W, Keys.D, Keys.A, Keys.R, Keys.Space);

            List<tiles> tiles = new List<tiles>();
            Texture2D squareTexture = Content.Load<Texture2D>("images/world/square");

            for (int i = 0; i < (Window.ClientBounds.Width / squareTexture.Width); i++)
            {
                tiles.Add(new tiles(squareTexture,
                    new Vector2(i * squareTexture.Width, Window.ClientBounds.Height - squareTexture.Height)));
            }
            world = new world(tiles);
		}
			
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit ();
			}
            p1.Update(null, world);			
			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

            spriteBatch.Begin();
            p1.Draw(spriteBatch);
            world.Draw(spriteBatch);
            spriteBatch.End();
            
			base.Draw (gameTime);
		}
	}
}

