using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MonoGameAutoTile.Game.TileMap
{
    public class TilemapObject
    {
        public string Name { get; set; }
        private string path { get; set; }

        [JsonIgnore] private Rectangle Rect;
        
        [JsonIgnore] private Texture2D texture;
        [JsonIgnore] public Vector2 Position;
        [JsonIgnore] public Vector2 Offset;


        public int ObjIndex = -1;





        public static TilemapObject ObjectFromJson(string filePath, GraphicsDevice graphicsDevice)
        {
            string json = File.ReadAllText(filePath);
            TilemapObject instance = JsonSerializer.Deserialize<TilemapObject>(json);
            
            string imagePath = Path.ChangeExtension(filePath, ".png");
            instance.path = filePath;

            using (Stream fileStream = File.OpenRead(imagePath))
            {
                instance.texture = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            instance.Rect = new Rectangle(0, 0, instance.texture.Width, instance.texture.Height);
            
            return instance;
        }

        public TilemapObject Copy()
        {
            var newObject = new TilemapObject();
            newObject.texture = this.texture;
            newObject.Name = Name;
            newObject.path = path;
            newObject.Rect = Rect;

            return newObject;
        }

        public void Update(float gt)
        {
            
        }
        
        

        public void Draw(SpriteBatch sb,Vector2 objPos, List<TilemapObject> objects)
        {
            if (ObjIndex != -1)
            {
                var renderObject = objects.FirstOrDefault(x => x.ObjIndex == ObjIndex);

                sb.Draw(renderObject.texture, objPos + renderObject.Offset, renderObject.Rect, 
                    Color.White, 0, new Vector2(0,0),new Vector2(1,1), 
                    SpriteEffects.None, 0);
            }
            
        }
    }
}