namespace TNE.Domain.Entities
{
    public class Equipment : Entity, INamedEntity
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}