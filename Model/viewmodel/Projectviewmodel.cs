using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class Projectviewmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public decimal? income { get; set; }
        public decimal? expense { get; set; }
        public int ordernumber { get; set; }
    }
}
