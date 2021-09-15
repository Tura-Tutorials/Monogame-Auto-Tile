﻿using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameAutoTile.Game.TileMap
{
    public class TileLayer
    {
        public string Name { get; set; }

        protected int tileWidth;
        protected int tileHeight;
        public Tile[,] tiles;
        


        public Tile[,] Tiles => tiles;

        public TileLayer(int tileWidth, int tileHeight, int width, int height, string name)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            Name = name;

            tiles = new Tile[width, height];
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    tiles[x, y] = new Tile();
                }
            }
        }

        internal TileLayer(BinaryReader reader)
        {
            Load(reader);
        }

        

        public TilePositionDetail GetTileAtPosition(Vector2 position)
        {
            TilePositionDetail detail = new TilePositionDetail();

            int x = (int)position.X / tileWidth;
            int y = (int)position.Y / tileHeight;

            detail.Coordinates = new Point(x, y);

            if (x < 0 || y < 0 || x > tiles.GetUpperBound(0) || y > tiles.GetUpperBound(1))
            {
                detail.IsValidPosition = false;
                return detail;
            }

            detail.IsValidPosition = true;
            detail.Tile = tiles[x, y];
            return detail;
        }

        public TilePositionDetail GetTileAtTilePos(Vector2 position)
        {
            TilePositionDetail detail = new TilePositionDetail();

            int x = (int) position.X;
            int y = (int) position.Y;
            
            detail.Coordinates = new Point(x, y);
            detail.Tile = tiles[x, y];
            
            return detail;
        }

        public virtual void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets, List<TilemapObject> objects)
        {
            
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                    Tile tile = tiles[x, y];
                    tile.Draw(pSpriteBatch, tilePosition, tileWidth, tileHeight, tilesets);
                    
                    
                }
            }
            
            
            
        }

        public void TileCallculate(List<Tileset> tilesets)
        {
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    
                    
                    
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        internal void Save(BinaryWriter writer)
        {
            writer.Write(tileWidth);
            writer.Write(tileHeight);
            writer.Write(Name);
            writer.Write(tiles.GetLength(0));
            writer.Write(tiles.GetLength(1));

            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    writer.Write(tiles[x, y].TilesetIndex);
                    writer.Write(tiles[x, y].TileIndex);
                    writer.Write(tiles[x, y].hasSprite);
                }
            }
        }

        private void Load(BinaryReader reader)
        {
            tileWidth = reader.ReadInt32();
            tileHeight = reader.ReadInt32();
            Name = reader.ReadString();
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();

            tiles = new Tile[width, height];
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    tiles[x, y] = new Tile()
                    {
                        TilesetIndex = reader.ReadInt32(),
                        TileIndex = reader.ReadInt32(),
                        hasSprite = reader.ReadBoolean()
                    };
                }
            }
        }

        public class TilePositionDetail
        {
            public Tile Tile { get; set; }

            public TilemapObject obj { get; set; }
            public Point Coordinates { get; set; }
            public bool IsValidPosition { get; set; }
            
            
        }
    }
}