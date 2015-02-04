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
    public class World
    {
        int worldSize;
        Texture2D texture;
        public Tile[,] map;
        public List<particle> worldParticles = new List<particle>();
        public Texture2D firesprite;
        int numberOfTilesInTexture;
        

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

        }

        public void Draw(SpriteBatch spriteBatch, Camera cam)
        {
            //Vi gör en rektangel lika stor som kameran. 
            Rectangle camRect = new Rectangle(
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
                    Rectangle tileRect = new Rectangle(x * (texture.Width / numberOfTilesInTexture), y * texture.Height, texture.Width / numberOfTilesInTexture, texture.Height);

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
                part.Draw(spriteBatch);
            }

        }
    }
}

