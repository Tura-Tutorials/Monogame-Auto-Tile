using System;
using System.Data;
using System.IO;

using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MonoGameAutoTile.Game.TileMap
{
    public class Tilemap
    {
        
        public delegate void OnNewMapHandler(Map newMap);
        public event OnNewMapHandler NewMap;
        
        public Map map;

        private GraphicsDevice gd;
        private Size2 viewportSize;
        private OrthographicCamera camera;
        public TilemapHelper tmHelper;

        public Tilemap(GraphicsDevice gd)
        {
            this.gd = gd;
            tmHelper = new TilemapHelper(gd, @"..\..\..\Content");
            camera = new OrthographicCamera(gd)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };

            CreateMap(10, 10, 32, 32);
        }
        
        public void CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            map = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
            NewMap?.Invoke(map);
        }

        public void UpdateMapSize(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            map.SetSize(tileWidth, tileHeight, mapWidth, mapHeight);
        }
        
        public void Draw(SpriteBatch sb, float dt)
        {
            map.Draw(sb, camera, tmHelper.Tilesets, tmHelper.Objects);
        }
    }
}