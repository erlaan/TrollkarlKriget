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
        World world; //The map
        public Camera cam;

		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.8);
            graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.8);
			graphics.IsFullScreen = false;
            graphics.ApplyChanges();
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
            new Vector2(0, 100),
            Keys.W, Keys.D, Keys.A, Keys.R, Keys.Space);
            Texture2D tile_texture = Content.Load<Texture2D>("images/world/square");

            cam = new Camera();
            world = new World(tile_texture);
            world.firesprite = Content.Load<Texture2D>("images/flamesprite");
            world.cam = cam; 
		}
			
		protected override void Update (GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit ();
			}
            p1.Update(null, world, gameTime);
            List<particle> newlist = new List<particle>();
            foreach (particle part in world.worldParticles)
            {
                part.Update(world, gameTime);
                if (!(part.endTime<=gameTime.TotalGameTime.TotalMilliseconds))
                newlist.Add(part);
            }
            world.worldParticles = newlist;
            cam.Update (gameTime,p1);
			base.Update (gameTime);
		}
			

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

            spriteBatch.Begin();
            world.Draw(spriteBatch, cam);
            p1.Draw(spriteBatch, cam);
            spriteBatch.End();
            
			base.Draw (gameTime);
		}
	}
}

