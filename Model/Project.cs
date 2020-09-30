using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? Ordernumber { get; set; }
    }
}
