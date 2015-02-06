using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Wizards
{
    public class World
    {
        int worldSize;
        Texture2D texture;
        public Tile[,] map;
        public List<particle> worldParticles = new List<particle>();
        public Texture2D firesprite;
        int numberOfTilesInTexture;
        private System.Drawing.Color myColor;
        

        public World(Texture2D texture)
        {
            worldSize = 100;
            this.texture = texture;

            map = new Tile[worldSize, worldSize];

            Random rnd = new Random();

            numberOfTilesInTexture = 1;

            Console.WriteLine(numberOfTilesInTexture); 

            for (int x = 0; x < worldSize; x++)
            {
                for (int y = 0; y < worldSize; y++)
                {
                    int type = rnd.Next(0, numberOfTilesInTexture);
                    map[x, y] = new Tile(type, new Vector2(x * (texture.Width), y * (texture.Height)), texture);

                }
            }

            Bitmap level = new Bitmap("Content/images/world/level.png");

            for (int x = 0; x < level.Width; x++)
            {
                for (int y = 0; y < level.Height; y++)
                {
                    myColor = level.GetPixel(x, y);
                    if (myColor == System.Drawing.Color.FromArgb(255, 0, 0)) ; 
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Camera cam)
        {
            //Vi gör en rektangel lika stor som kameran. 
            Microsoft.Xna.Framework.Rectangle camRect = new Microsoft.Xna.Framework.Rectangle(
                                    Convert.ToInt32(cam.position.X),
                                    Convert.ToInt32(cam.position.Y),
                (cam.width + 1) * (texture.Width / numberOfTilesInTexture),
                (cam.height + 2) * texture.Height);

            //vi loopar igenom ALLA rutor
            for (int x = 0; x < worldSize; x++)
            {
                for (int y = 0; y < worldSize; y++)
                {

                    //För varje ruta så gör vi en rektangel-
                    Microsoft.Xna.Framework.Rectangle tileRect = new Microsoft.Xna.Framework.Rectangle(x * (texture.Width / numberOfTilesInTexture), y * texture.Height, texture.Width / numberOfTilesInTexture, texture.Height);

                    //och så kollar vi om rektangeln för rutan är inom rektangeln för kameran.
                    if (tileRect.Intersects(camRect))
                    {

                        //isåfall så ritar vi ut den. vi skickar med kamerans position för att kunna offsetta det vi ritar ut.  
                        map[x, y].Draw(spriteBatch, cam.position);

                    }
                }
            }
            foreach (particle part in worldParticles)
            {
                part.Draw(spriteBatch, cam);
            }

        }
    }
}

