namespace TNE.Domain.Entities
{

    public enum TextRowSubtype
    {
        Plain,
        Header,
        Line,
        TableHead,
        TableRow,
        TableCostRow,
    }

    public class TextRow : DataRow
    {
        public override RowType Type => RowType.Text;
        
        public string Text { get; set; }
        
        public TextRowSubtype Subtype { get; set; }
        
        public string Options { get; set; }
        
    }
}