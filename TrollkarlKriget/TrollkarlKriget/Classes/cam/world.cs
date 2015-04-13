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
        public int worldSize;
        Texture2D texture;
        public Tile[,] map;
        public List<particle> worldParticles = new List<particle>();
        public Texture2D firesprite;
        public Camera cam;
        int numberOfTilesInTexture;
        private System.Drawing.Color myColor;
        public int gravity;
        List<enemy> enemies;

        public World(Texture2D texture, Texture2D enemyTexture)
        {
            gravity = 9; 
            
            this.texture = texture;

            enemies = new List<enemy> ();


            Random rnd = new Random();

            numberOfTilesInTexture = texture.Width / Settings.gridsize;


            Bitmap level = new Bitmap("../../../../TrollkarlKrigetContent/images/world/level.png");

            worldSize = level.Width;

            map = new Tile[worldSize, worldSize];

            for (int x = 0; x < worldSize; x++)
            {
                for (int y = 0; y < worldSize; y++)
                {
                    myColor = level.GetPixel(x, y);
                    if (myColor == System.Drawing.Color.FromArgb(255, 0, 0))
                    {
                        map[x, y] = new Tile(2, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                    }
                    else if (myColor == System.Drawing.Color.FromArgb(0, 0, 0))
                    {
                        map[x, y] = new Tile(3, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                    }
                    else if (myColor == System.Drawing.Color.FromArgb(0, 0, 255))
                    {
                        //Enemy Underground boss.
                        map[x, y] = new Tile(1, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                        
                    }
                    else if (myColor == System.Drawing.Color.FromArgb(255, 0, 255))
                    {
                        //Portal
                        map[x, y] = new Tile(1, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                    }
                    else if (myColor == System.Drawing.Color.FromArgb(255, 10, 255))
                    {
                        //Boss på första leveln
                        map[x, y] = new Tile(1, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                    }
                    /*else if (myColor == System.Drawing.Color.FromArgb(255, 25, 255))
                    {
                        // Alla enemies spawnar med den här Färg checken
                        map[x, y] = new Tile(0, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                        enemies.Add(new enemy (enemyTexture, new Vector2 (x * Settings.gridsize, y * Settings.gridsize), new Vector2(1,0)));
                    }*/
                    else
                    {
                        map[x, y] = new Tile(0, new Vector2(x * (texture.Width / numberOfTilesInTexture), y * (texture.Height)), texture);
                    }
                }
            }

        }

        public void Update(GameTime gameTime)
        {
            foreach (var e1 in enemies)
            {
                e1.Update(this);
                e1.checkCollision(cam, this);

            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera cam)
        {

            cam.visibleTiles.Clear();

            //vi loopar igenom ALLA rutor  int x = 0; x < worldSize; x++ || int y = 0; y < worldSize; y++
            for (int x = (int)((cam.position.X / Settings.gridsize)); x <= (int)((cam.position.X + cam.width) / Settings.gridsize); x++)
            {
                for (int y = (int)((cam.position.Y / Settings.gridsize)); y <= (int)((cam.position.Y + cam.height) / Settings.gridsize); y++)
                {


                    if (x >= 0 &&
                        y >= 0 &&
                        x<=(worldSize-1) && 
                        y<=(worldSize-1) )
                    {

                        //isåfall så ritar vi ut den. vi skickar med kamerans position för att kunna offsetta det vi ritar ut.
                        try{
                            cam.visibleTiles.Add(map[x, y]);
                            map[x, y].Draw(spriteBatch, cam.position);
                            
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            foreach (particle part in worldParticles)
            {
                part.Draw(spriteBatch, cam);
            }
            foreach (var e1 in enemies)
            {
                e1.Draw(spriteBatch, cam);
            }

        }
    }
}

