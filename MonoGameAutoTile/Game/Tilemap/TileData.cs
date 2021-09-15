using Microsoft.Xna.Framework;

namespace MonoGameAutoTile.Game.TileMap
{
    public class TileData
    {
        
        public Rectangle rect { get; set; }

        public bool N { get; set; }
        public bool E { get; set; }
        public bool S { get; set; }
        public bool W { get; set; }

        public TileData()
        {
            
        }

        public TileData(Rectangle rec, bool n, bool e, bool s, bool w)
        {
            rect = rec;
            N = n;
            E = e;
            S = s;
            W = w;
        }
        
    }
}