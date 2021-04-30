namespace MapLib.Elements
{
    public class EntityKey
    {
        public string Name { get; set; }
        public string Value { get; set; }
        
        public override string ToString()
        {
            return string.Format("\"{0}\" \"{1}\"", this.Name, this.Value);
        }
    }
}
