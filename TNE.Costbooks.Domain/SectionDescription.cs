namespace TNE.Domain.Entities
{
    public class SectionDescription : Entity
    {
        public long SectionId { get; set; }
        public SectionRow Section { get; set; }

        public string Text { get; set; }
    }
}