using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MonoGameAutoTile.Game.TileMap
{
    [Serializable]
    public class Tileset
    {
        
        
        public string FilePath { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public Texture2D Texture { get; set; }

        public List<TileData> Tiles { get; set; }
        

        public static Tileset FromJsonFile(string filePath, GraphicsDevice graphicsDevice)
        {

            string json = File.ReadAllText(filePath);
            Tileset instance = JsonConvert.DeserializeObject<Tileset>(json);
            
            
            string imagePath = Path.ChangeExtension(filePath, ".png");
            instance.FilePath = filePath;

            using (Stream fileStream = File.OpenRead(imagePath))
            {
                instance.Texture = Texture2D.FromStream(graphicsDevice, fileStream);
            }

            Console.WriteLine(instance.Tiles.Count);
            
            
            
            return instance;
        }

        public Tileset()
        {
            FilePath = Path.ChangeExtension("/Content/Textures/Map/Tiles/", ".png");

        }

        public Tileset(Tileset source)
        {
            Apply(source);
        }

        public void Apply(Tileset source)
        {
            Name = source.Name;
            Texture = source.Texture;

            Tiles = new List<TileData>(source.Tiles);

            
        }

        public void SaveToJson()
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}