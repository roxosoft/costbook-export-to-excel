namespace TNE.Domain.Entities
{
    public class CrewComposition : Entity
    {
        public long CrewId { get; set; }
        public long LaborerId { get; set; }
        public int Count { get; set; }
    }
}