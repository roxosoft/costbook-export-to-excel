namespace TNE.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }
    }

    public interface INamedEntity
    {
        string Name { get; set; }
    }
}