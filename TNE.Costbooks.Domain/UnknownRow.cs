namespace TNE.Domain.Entities
{
    public class UnknownRow : Row
    {
        public string Text { get; set; }

        public override RowType Type => RowType.Unknown;
        public override int GetLevel()
        {
            return 0;
        }
    }
}