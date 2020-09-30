using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACCOUNTINGSHEET.Model;
using ACCOUNTINGSHEET.Model.repositories;
using Microsoft.EntityFrameworkCore;
using System.Web;
namespace ACCOUNTINGSHEET.Model.repositories
{
    public class BaseRepository 
    {
        protected readonly DB_A66DAB_accountingsheetContext db;    

        public BaseRepository(){
              DB_A66DAB_accountingsheetContext _db=new DB_A66DAB_accountingsheetContext();
             db=_db;
        }
        public void Save()
        {
            db.SaveChanges();           
        }
       
       
    }
}
