namespace ShaderLib.Elements.Directives.Attributes
{
    public sealed class SurfaceParmType
    {
        public static readonly SurfaceParmType AlphaShadow = new SurfaceParmType("alphaShadow");
        public static readonly SurfaceParmType AntiPortal =new SurfaceParmType( "antiPortal");
        public static readonly SurfaceParmType AreaPortal =new SurfaceParmType( "areaPortal");
        public static readonly SurfaceParmType BotClip =new SurfaceParmType( "botClip");
        public static readonly SurfaceParmType ClusterPortal = new SurfaceParmType("clusterPortal");
        public static readonly SurfaceParmType Detail =new SurfaceParmType( "detail");
        public static readonly SurfaceParmType DoNotEnter = new SurfaceParmType("doNotEnter");
        public static readonly SurfaceParmType Dust =new SurfaceParmType( "dust");
        public static readonly SurfaceParmType Flesh = new SurfaceParmType("flesh");
        public static readonly SurfaceParmType Fog = new SurfaceParmType("fog");
        public static readonly SurfaceParmType Hint = new SurfaceParmType("hint");
        public static readonly SurfaceParmType Ladder = new SurfaceParmType("ladder");
        public static readonly SurfaceParmType Lava = new SurfaceParmType("lava");
        public static readonly SurfaceParmType LightFilter = new SurfaceParmType("lightFilter");
        public static readonly SurfaceParmType LightGrid =new SurfaceParmType( "lightGrid");
        public static readonly SurfaceParmType MetalSteps = new SurfaceParmType("metalSteps");
        public static readonly SurfaceParmType MonsterClip = new SurfaceParmType("monsterClip");
        public static readonly SurfaceParmType NoDamage =new SurfaceParmType( "noDamage");
        public static readonly SurfaceParmType NoDLight = new SurfaceParmType("noDLight");
        public static readonly SurfaceParmType NoDraw = new SurfaceParmType("noDraw");
        public static readonly SurfaceParmType NoDrop = new SurfaceParmType("noDrop");
        public static readonly SurfaceParmType NoImpact = new SurfaceParmType("noImpact");
        public static readonly SurfaceParmType NoMarks = new SurfaceParmType("noMarks");
        public static readonly SurfaceParmType NoLightMap = new SurfaceParmType("noLightMap");
        public static readonly SurfaceParmType NoSteps = new SurfaceParmType("noSteps");
        public static readonly SurfaceParmType NonSolid = new SurfaceParmType("nonSolid");
        public static readonly SurfaceParmType Origin = new SurfaceParmType("origin");
        public static readonly SurfaceParmType PlayerClip = new SurfaceParmType("playerClip");
        public static readonly SurfaceParmType PointLight = new SurfaceParmType("pointLight");
        public static readonly SurfaceParmType Skip = new SurfaceParmType("skip");
        public static readonly SurfaceParmType Sky = new SurfaceParmType("sky");
        public static readonly SurfaceParmType Slick =new SurfaceParmType( "slick");
        public static readonly SurfaceParmType Slime = new SurfaceParmType("slime");
        public static readonly SurfaceParmType Structural =new SurfaceParmType( "structural");
        public static readonly SurfaceParmType Trans =new SurfaceParmType( "trans");
        public static readonly SurfaceParmType Water = new SurfaceParmType("water");

        public static readonly SurfaceParmType Tin = new SurfaceParmType("tin");
        public static readonly SurfaceParmType Aluminium = new SurfaceParmType("aluminium");
        public static readonly SurfaceParmType Iron = new SurfaceParmType("iron");
        public static readonly SurfaceParmType Titanium = new SurfaceParmType("titanium");
        public static readonly SurfaceParmType Steel = new SurfaceParmType("steel");
        public static readonly SurfaceParmType Copper = new SurfaceParmType("copper");
        public static readonly SurfaceParmType Brass =new SurfaceParmType( "brass");
        public static readonly SurfaceParmType Cement =new SurfaceParmType( "cement");
        public static readonly SurfaceParmType Rock = new SurfaceParmType("rock");
        public static readonly SurfaceParmType Gravel = new SurfaceParmType("gravel");
        public static readonly SurfaceParmType Pavement = new SurfaceParmType("pavement");
        public static readonly SurfaceParmType Brick = new SurfaceParmType("brick");
        public static readonly SurfaceParmType Clay = new SurfaceParmType("clay");
        public static readonly SurfaceParmType Grass = new SurfaceParmType("grass");
        public static readonly SurfaceParmType Dirt = new SurfaceParmType("dirt");
        public static readonly SurfaceParmType Mud = new SurfaceParmType("mud");
        public static readonly SurfaceParmType Snow = new SurfaceParmType("snow");
        public static readonly SurfaceParmType Ice = new SurfaceParmType("ice");
        public static readonly SurfaceParmType Sand = new SurfaceParmType("sand");
        public static readonly SurfaceParmType CeramicTile = new SurfaceParmType("ceramicTile");
        public static readonly SurfaceParmType Linoleum = new SurfaceParmType("linoleum");
        public static readonly SurfaceParmType Rug = new SurfaceParmType("rug");
        public static readonly SurfaceParmType Plaster = new SurfaceParmType("plaster");
        public static readonly SurfaceParmType Plastic = new SurfaceParmType("plastic");
        public static readonly SurfaceParmType CardBoard = new SurfaceParmType("cardBoard");
        public static readonly SurfaceParmType HardWood = new SurfaceParmType("hardWood");
        public static readonly SurfaceParmType SoftWood = new SurfaceParmType("softWood");
        public static readonly SurfaceParmType Plank = new SurfaceParmType("plank");
        public static readonly SurfaceParmType Glass = new SurfaceParmType("glass");
        public static readonly SurfaceParmType Stucco = new SurfaceParmType("stucco");

        public static readonly SurfaceParmType NoLightmap = new SurfaceParmType("noLightmap");
        public static readonly SurfaceParmType NonOpaque = new SurfaceParmType("nonOpaque");
        public static readonly SurfaceParmType Strip = new SurfaceParmType("strip");

        public SurfaceParmType(string value)
        {
            this.Value = value;
        }

        public string Value { get; private set; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
