using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameAutoTile.Game.TileMap
{
    public class ObjectLayer : TileLayer
    {
        

        private TilemapObject[,] objects;

        public TilemapObject[,] Objects => objects;


        public ObjectLayer(int tileWidth, int tileHeight, int width, int height, string name) : base(tileWidth,
            tileHeight, width, height, name)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            Name = name;

            objects = new TilemapObject[width, height];
            for (int x = 0; x < objects.GetLength(0); x++)
            {
                for (int y = 0; y < objects.GetLength(1); y++)
                {
                    objects[x, y] = new TilemapObject();
                }
            }
        }

        public TilePositionDetail GetObjAtPosition(Vector2 position)
        {
            TilePositionDetail detail = new TilePositionDetail();

            int x = (int)position.X / tileWidth;
            int y = (int)position.Y / tileHeight;

            detail.Coordinates = new Point(x, y);

            if (x < 0 || y < 0 || x > objects.GetUpperBound(0) || y > objects.GetUpperBound(1))
            {
                detail.IsValidPosition = false;
                return detail;
            }

            detail.IsValidPosition = true;
            detail.obj = objects[x, y];
            return detail;
        }
        
        
        private void Load(BinaryReader reader)
        {
            tileWidth = reader.ReadInt32();
            tileHeight = reader.ReadInt32();
            Name = reader.ReadString();
            int width = reader.ReadInt32();
            int height = reader.ReadInt32();

            objects = new TilemapObject[width, height];
            for (int x = 0; x < objects.GetLength(0); x++)
            {
                for (int y = 0; y < objects.GetLength(1); y++)
                {
                    objects[x, y] = new TilemapObject()
                    {
                        ObjIndex = reader.ReadInt32()
                    };
                }
            }
        }

        internal void Save(BinaryWriter writer)
        {
            writer.Write(tileWidth);
            writer.Write(tileHeight);
            writer.Write(Name);
            writer.Write(objects.GetLength(0));
            writer.Write(objects.GetLength(1));

            for (int x = 0; x < objects.GetLength(0); x++)
            {
                for (int y = 0; y < objects.GetLength(1); y++)
                {
                    writer.Write(objects[x, y].ObjIndex);
                }
            }
        }
        

        


        public override void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets, List<TilemapObject> objects)
        {
            
        }
    }
}