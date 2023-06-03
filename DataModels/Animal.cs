namespace AnimalibAPI.DataModels
{
    public class Animal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string Regions { get; set; }

        public string Species { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}
