namespace AnimalibAPI.DataModels
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Int64 Size { get; set; }

        public int SpeciesCount { get; set; }

        public byte[] Image { get; set; }
    }
}
