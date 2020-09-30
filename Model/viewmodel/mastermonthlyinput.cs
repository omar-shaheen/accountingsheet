using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Model
{
    public partial class mastermonthlyinput
    {
        public mastermonthlyinput(){
            Incomes=new List<Monthlyinput>();
            Expenses=new List<Monthlyinput>();
            Deletedincomes=new List<Monthlyinput>();
            Deletedexpenses=new List<Monthlyinput>();
        }
        public int Currentmonth { get; set; }
        public int Currentyear { get; set; }
        public List<Monthlyinput> Incomes{ get; set; }
        public List<Monthlyinput> Expenses{ get; set; }
        public List<Monthlyinput> Deletedincomes{ get; set; }
        public List<Monthlyinput> Deletedexpenses{ get; set; }
    }
}