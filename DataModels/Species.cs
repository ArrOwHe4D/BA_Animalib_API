namespace AnimalibAPI.DataModels
{
    public class Species
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int AnimalCount { get; set; }

        public byte[] Image { get; set; }
    }
}
