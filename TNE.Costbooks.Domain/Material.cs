namespace TNE.Domain.Entities
{
    public class Material : Entity, INamedEntity
    {
        public string Name { get; set; }

        public Material Parent { get; set; }
        public long? ParentId { get; set; }
    }
}