using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Model
{
    public partial class mastertaskcost
    {
        public mastertaskcost(){
            Taskcosts=new List<Taskcost>();
            Deletedtaskcosts=new List<Taskcost>();  
        } 
        public List<Taskcost> Taskcosts{ get; set; }
        public List<Taskcost> Deletedtaskcosts{ get; set; }
    }
}