using System.Collections.Generic;

namespace TNE.Domain.Entities
{
    public class PageRow : Row
    {
        public override RowType Type => RowType.Page;

        public override int GetLevel()
        {
            return 0;
        }

        public string Title { get; set; }
    }
}