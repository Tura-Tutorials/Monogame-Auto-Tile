using System;
using System.Collections.Generic;
using System.IO;
using Endorblast.Lib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameAutoTile.Game.TileMap
{
    public class Map
    {
        public List<TileLayer> Layers { get; private set; }
        public CollisionLayer CollisionLayer { get; private set; }

        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;
        private List<Tuple<int, int, Tile>> immediateTiles = new List<Tuple<int, int, Tile>>();
        private List<Tuple<int, int, TilemapObject>> immediateObjects = new List<Tuple<int, int, TilemapObject>>();

        private TilemapObject tempObject = new TilemapObject();

        public int TileWidth
        {
            get => tileWidth;
        }
        public int TileHeight
        {
            get => tileHeight;
        }

        public int Width
        {
            get => width;
        }

        public int Height
        {
            get => height;
        }

        public Map(int tileWidth, int tileHeight, int width, int height)
        {
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.width = width;
            this.height = height;
            Layers = new List<TileLayer>();
            Layers.Add(new TileLayer(tileWidth, tileHeight, width, height, "Layer 1"));

            CollisionLayer = new CollisionLayer(tileWidth, tileHeight, width, height);
        }

        private void SetEverything(int tileWidth, int tileHeight, int width, int height)
        {
            
        }

        
        
        public Map(Stream stream)
        {
            Layers = new List<TileLayer>();
            Load(stream);
        }

        public TileLayer.TilePositionDetail GetTileAtPosition(Vector2 position, int layerIndex)
        {
            if (layerIndex < 0 || layerIndex >= Layers.Count)
                return null;

            
            
            if (Layers[layerIndex].GetType() == typeof(ObjectLayer))
            {
                var layerTest = (ObjectLayer) Layers[layerIndex];
                return layerTest.GetObjAtPosition(position);
            }
            
            return Layers[layerIndex].GetTileAtPosition(position);
        }

        public CollisionLayer.CellPositionDetail GetCellAtPosition(Vector2 position)
        {
            return CollisionLayer.GetCellAtPosition(position);
        }

        public void AddImmediateTile(int x, int y, Tile tile)
        {
            immediateTiles.Add(new Tuple<int, int, Tile>(x, y, tile));
        }

        public void TempObjToPoint(int x, int y, TilemapObject objIndex)
        {
            immediateObjects.Add(new Tuple<int, int, TilemapObject>(x, y, objIndex));
        }
        
        public void AddObjectAtPoint(float x, float y, TilemapObject objIndex)
        {
            
        }
        

        public void SetSize(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            int changeX = mapWidth - Width;
            int changeY = mapHeight - Height;

            width = mapWidth;
            height = mapHeight;
            
            

            foreach (var layer in Layers)
            {
                var newLayer = new TileLayer(tileWidth, tileHeight, mapWidth, mapHeight, layer.Name);
                newLayer.tiles = new Tile[mapWidth, mapHeight];

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        if (i > width && i < mapWidth)
                        {
                            newLayer.tiles[i, j] = new Tile();
                        }
                        
                        if (j > height && i < mapHeight)
                        {
                            newLayer.tiles[i, j] = new Tile();
                        }
                    }
                }
                
                
            }
        }

        public void Smooth()
        {
            SpriteInt();
        }
        

        public void Draw(SpriteBatch pSpriteBatch, Camera<Vector2> camera, List<Tileset> tilesets, List<TilemapObject> objects)
        {
            pSpriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            

            for (int i = 0; i < Layers.Count; i++)
            {
                Layers[i].TileCallculate(tilesets);
                Layers[i].Draw(pSpriteBatch, camera, tilesets, objects);
            }

            CollisionLayer.Draw(pSpriteBatch, camera);

            for (int i = 0; i < immediateTiles.Count; i++)
            {
                var (x, y, tile) = immediateTiles[i];
                Vector2 tilePosition = new Vector2(x * tileWidth, y * tileHeight);
                tile.Draw(pSpriteBatch, tilePosition, tileWidth, tileHeight, tilesets);
            }
            
            
            
            
            pSpriteBatch.DrawRectangle(new Vector2(0,0), new Size2(width * TileWidth, height * TileHeight), Color.White);
            
            
            
            pSpriteBatch.End();
            immediateObjects.Clear();
            immediateTiles.Clear();
        }

        public void Save(Stream stream)
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(width);
                writer.Write(height);
                writer.Write(tileWidth);
                writer.Write(tileHeight);
                writer.Write(Layers.Count);
                for (int i = 0; i < Layers.Count; i++)
                {
                    Layers[i].Save(writer);
                }
                CollisionLayer.Save(writer);
            }
        }

        private void Load(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                width = reader.ReadInt32();
                height = reader.ReadInt32();
                tileWidth = reader.ReadInt32();
                tileHeight = reader.ReadInt32();
                int layerCount = reader.ReadInt32();
                for (int i = 0; i < layerCount; i++)
                {
                    Layers.Add(new TileLayer(reader));
                }
                CollisionLayer = new CollisionLayer(reader);
            }
        }
        
        private bool IsValid(Map map, Vector2 position)
        {
            if (position.X < 0 || position.Y < 0)
                return false;

            if (position.X > map.Width - 1 || position.Y > map.Height - 1)
                return false;

            return true;
        }

        private bool HasTile(Map map, Vector2 thisTile, int tilesetIndex, int activeLayer)
        {
            if (!IsValid(map, thisTile))
                return false;
            
            var tile = map.Layers[activeLayer].GetTileAtTilePos(thisTile);
            
            if (tile.Tile.TilesetIndex == -1 && tilesetIndex ==  1)
            {
                return false;
            }
            
            if (tile.Tile.TilesetIndex == 0 && tilesetIndex != 0)
            {
                return true;
            }

            if (!tile.Tile.hasSprite)
                return false;

            return true;
        }

        private void SpriteInt()
        {
            int spriteId = -1;

            for (int i = 0; i < Layers.Count; i++)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        var pos = new Vector2(x, y);

                        var tile = this.Layers[i].GetTileAtTilePos(pos);

                        var tileInx = tile.Tile.TilesetIndex;

                        bool NW = HasTile(this, pos + new Vector2(-1, -1),tileInx,i);
                        bool N = HasTile(this, pos + new Vector2(0, -1),tileInx,i);
                        bool NE = HasTile(this, pos + new Vector2(1, -1),tileInx,i);
                        bool W = HasTile(this, pos + new Vector2(-1, 0),tileInx,i);
                        bool E = HasTile(this, pos + new Vector2(1, 0),tileInx,i);
                        bool SW = HasTile(this, pos + new Vector2(-1, 1),tileInx,i);
                        bool S = HasTile(this, pos + new Vector2(0, 1),tileInx,i);
                        bool SE = HasTile(this, pos + new Vector2(1, 1),tileInx,i);
                        
                        spriteId = CalculateTileFlags(E, W, N, S, NW, NE, SW, SE);

                        switch (spriteId)
                        {
                            case 2:
                                spriteId = 1;
                                break;
                            case 8:
                                spriteId = 2;
                                break;
                            case 10:
                                spriteId = 3;
                                break;
                            case 11:
                                spriteId = 4;
                                break;
                            case 16:
                                spriteId = 5;
                                break;
                            case 18:
                                spriteId = 6;
                                break;
                            case 22:
                                spriteId = 7;
                                break;
                            case 24:
                                spriteId = 8;
                                break;
                            case 26:
                                spriteId = 9;
                                break;
                            case 27:
                                spriteId = 10;
                                break;
                            case 30:
                                spriteId = 11;
                                break;
                            case 31:
                                spriteId = 12;
                                break;
                            case 64:
                                spriteId = 13;
                                break;
                            case 66:
                                spriteId = 14;
                                break;
                            case 72:
                                spriteId = 15;
                                break;
                            case 74:
                                spriteId = 16;
                                break;
                            case 75:
                                spriteId = 17;
                                break;
                            case 80:
                                spriteId = 18;
                                break;
                            case 82:
                                spriteId = 19;
                                break;
                            case 86:
                                spriteId = 20;
                                break;
                            case 88:
                                spriteId = 21;
                                break;
                            case 90:
                                spriteId = 22;
                                break;
                            case 91:
                                spriteId = 23;
                                break;
                            case 94:
                                spriteId = 24;
                                break;
                            case 95:
                                spriteId = 25;
                                break;
                            case 104:
                                spriteId = 26;
                                break;
                            case 106:
                                spriteId = 27;
                                break;
                            case 107:
                                spriteId = 28;
                                break;
                            case 120:
                                spriteId = 29;
                                break;
                            case 122:
                                spriteId = 30;
                                break;
                            case 123:
                                spriteId = 31;
                                break;
                            case 126:
                                spriteId = 32;
                                break;
                            case 127:
                                spriteId = 33;
                                break;
                            case 208:
                                spriteId = 34;
                                break;
                            case 210:
                                spriteId = 35;
                                break;
                            case 214:
                                spriteId = 36;
                                break;
                            case 216:
                                spriteId = 37;
                                break;
                            case 218:
                                spriteId = 38;
                                break;
                            case 219:
                                spriteId = 39;
                                break;
                            case 222:
                                spriteId = 40;
                                break;
                            case 223:
                                spriteId = 41;
                                break;
                            case 248:
                                spriteId = 42;
                                break;
                            case 250:
                                spriteId = 43;
                                break;
                            case 251:
                                spriteId = 44;
                                break;
                            case 254:
                                spriteId = 45;
                                break;
                            case 255:
                                spriteId = 46;
                                break;
                            case 0:
                                spriteId = 47;
                                break;
                        }

                        Console.WriteLine(pos + " " + spriteId);
                        tile.Tile.TileIndex = spriteId;
                    }
                }
            } 
        }
        
        private static int CalculateTileFlags(bool east, bool west, bool north, bool south, bool northWest,
            bool northEast, bool southWest, bool southEast)
        {
            int directions = (east ? 16 : 0) | (west ? 8 : 0) |
                             (north ? 2 : 0) | (south ? 64 : 0);
            directions |= ((north && west) && northWest) ? 1 : 0;
            directions |= ((north && east) && northEast) ? 4 : 0;
            directions |= ((south && west) && southWest) ? 32 : 0;
            directions |= ((south && east) && southEast) ? 128 : 0;
            return directions;
        }


        
    }
}