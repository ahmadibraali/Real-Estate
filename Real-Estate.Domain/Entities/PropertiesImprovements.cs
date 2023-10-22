namespace Real_Estate.Domain.Entities
{
    public class PropertiesImprovements
    {
        public int PropertyId { get; set; }
        public int ImprovementId { get; set; }

        public Properties? Property { get; set; }
        public Improvements? Improvement { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
