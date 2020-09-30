using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Model;
namespace ACCOUNTINGSHEET.Model
{
    public partial class masterproject
    {
        public masterproject(){
            Projects=new List<Project>();
            Deletedprojects=new List<Project>();  
        } 
        public List<Project> Projects{ get; set; }
        public List<Project> Deletedprojects{ get; set; }
    }
}