using System;
using System.Collections.Generic;

namespace ACCOUNTINGSHEET.Model
{
    public partial class MonthlyinputViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Projectid { get; set; }
        public int? Contractorid { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public string Notes { get; set; }
        public decimal? Incomeamount { get; set; }
        public decimal? Expenseamount { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Projectname { get; set; }
        public string Contractorname { get; set; }
        public string Taskcostname { get; set; }
        public int? Inputtype { get; set; }
        public int? Taskcostid { get; set; }
        
    }
}
