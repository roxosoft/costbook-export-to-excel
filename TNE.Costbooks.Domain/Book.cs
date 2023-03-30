using System;
using System.Collections.Generic;

namespace TNE.Domain.Entities
{
    public class Book : Entity
    {

        public Book()
        {
            Rows = new List<Row>();
        }

        public string Name { get; set; }

        public int? FirstPage { get; set; }

        public IList<Row> Rows { get; private set; }

        public DateTime ImportDate { get; set; }
    }

}
