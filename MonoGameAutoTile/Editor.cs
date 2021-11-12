using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input;
using MonoGameAutoTile.Game.TileMap;

namespace MonoGameAutoTile
{
    public class Editor
    {
        private Tilemap myMap;
        private OrthographicCamera camera;
        
        public Editor(GraphicsDevice gd)
        {
            myMap = new Tilemap(gd);
            camera = new OrthographicCamera(gd)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };
        }


        public void Update(GameTime gameTime)
        {
            MouseStateExtended mouseState = MouseExtended.GetState();
            KeyboardStateExtended keyboardState = KeyboardExtended.GetState();
            Point mousePosition = mouseState.Position;
            Vector2 worldPosition = camera.ScreenToWorld(mousePosition.ToVector2());
            var tile = myMap.map.GetTileAtPosition(worldPosition, 0);
            
            if (mouseState.WasButtonJustUp(MouseButton.Left) && tile != null)
            {
                tile.Tile.TileIndex = 0;
                tile.Tile.TilesetIndex = 0;
                tile.Tile.hasSprite = true;
                Console.WriteLine("Tile Left");
            }
            else if (mouseState.WasButtonJustUp(MouseButton.Right) && tile != null)
            {
                tile.Tile.TileIndex = -1;
                tile.Tile.TilesetIndex = -1;
                tile.Tile.hasSprite = false;
                Console.WriteLine("Tile Right");
            }
            
            if (keyboardState.WasKeyJustUp(Keys.S))
            {
                Console.WriteLine("Smooth");
                myMap.map.Smooth();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            myMap.Draw(sb);
        }
    }
}