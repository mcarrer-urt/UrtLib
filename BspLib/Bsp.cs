using BspLib.Elements;

namespace BspLib
{
    public class Bsp
    {
        public Header Header;

        public Entity Entity;
        public Texture[] Textures;
        public Plane[] Planes;
        public Node[] Nodes;
        public Leaf[] Leafs;
        public LeafFace[] LeafFaces;
        public LeafBrush[] LeafBrushs;
        public Model[] Models;
        public Brush[] Brushs;
        public BrushSide[] BrushSides;
        public Vertex[] Vertices;
        public MeshVert[] MeshVerts;
        public Effect[] Effects;
        public Face[] Faces;
        public LightMap[] LightMaps;
        public LightVol[] LightVols;
        public Visdata Visdata;

        public Bsp() { }

        public Bsp(string filepath)
        {
            Bsp bsp = BspReader.Read(filepath);

            Header = bsp.Header;
            Entity = bsp.Entity;
            Textures = bsp.Textures;
            Planes = bsp.Planes;
            Nodes = bsp.Nodes;
            Leafs = bsp.Leafs;
            LeafFaces = bsp.LeafFaces;
            LeafBrushs = bsp.LeafBrushs;
            Models = bsp.Models;
            Brushs = bsp.Brushs;
            BrushSides = bsp.BrushSides;
            Vertices = bsp.Vertices;
            MeshVerts = bsp.MeshVerts;
            Effects = bsp.Effects;
            Faces = bsp.Faces;
            LightMaps = bsp.LightMaps;
            LightVols = bsp.LightVols;
            Visdata = bsp.Visdata;
        }

        public void Save(string filepath)
        {
            BspWriter.Write(this, filepath);
        }
    }
}
