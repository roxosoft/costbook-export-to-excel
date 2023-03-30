namespace TNE.Domain.Entities
{
    public class Aggregate : Entity, INamedEntity
    {
        public string Name { get; set; }
    }
}