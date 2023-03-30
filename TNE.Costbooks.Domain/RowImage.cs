namespace TNE.Domain.Entities
{
    public class RowImage : Entity
    {
        public long RowId { get; set; }
        public Row Row { get; set; }

        public int Number { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
    }
}