namespace TNE.Domain.Entities
{
    public class SectionKeyword : Entity
    {
        public string Category { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public long SectionId { get; set; }
        public SectionRow Section { get; set; }
    }
}
