using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameAutoTile.Game.TileMap
{

    [Flags]
    public enum Directions
    {
        NorthWest  = 1 << 0,
        North = 1 << 1,
        NorthEast   = 1 << 2,
        West   = 1 << 3,
        East  = 1 << 4,
        SouthWest = 1 << 5,
        South   = 1 << 6,
        SouthEast   = 1 << 7,
    }

    
    
    public class Tile
    {
        private List<Vector2> colliderPoints = new List<Vector2>();

        public Color color = Color.White;

        public bool[] direction = new bool[9];

        public bool hasSprite { get; set; } = false;

        public bool S;
        public bool N;
        public bool E;
        public bool W;
        
        public int TilesetIndex { get; set; } = -1;
        
        public int TileIndex { get; set; } = -1;

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 tilePosition, int tileWidth, int tileHeight, List<Tileset> tilesets)
        {
            
            
            if (TilesetIndex != -1 && TileIndex != -1)
            {
                
                //spriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), color);
                
                Tileset tileset = tilesets[TilesetIndex];

                // Console.WriteLine($"{tileset.Tiles[TileIndex].N}, {tileset.Tiles[TileIndex].E}, {tileset.Tiles[TileIndex].S}, {tileset.Tiles[TileIndex].W}");
                //
                spriteBatch.Draw(tileset.Texture, tilePosition, tileset.Tiles[TileIndex].rect, color);
            }
            else
            {
                //spriteBatch.DrawRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.White);
            }
        }

        public Tile()
        {
            
        }

        public Tile(Color color, int setIndex = 1, int tileIndex = 1)
        {
            TilesetIndex = setIndex;
            TileIndex = tileIndex;
            this.color = color;
        }
    }
}