using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Model
{
    public partial class mastercontractor
    {
        public mastercontractor(){
            Contractors=new List<Contractor>();
            Deletedcontractors=new List<Contractor>();  
        } 
        public List<Contractor> Contractors{ get; set; }
        public List<Contractor> Deletedcontractors{ get; set; }
    }
}