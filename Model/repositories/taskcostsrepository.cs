using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Helper;

namespace ACCOUNTINGSHEET.Model.repositories
{
    public class taskcostsrepository :  RepositoryBase<Taskcost>
    {
       public taskcostsrepository(DB_A66DAB_accountingsheetContext _ctx): base(_ctx) {
            this.db=_ctx;
        } 

        
        // public IList<contractorviewmodel>  getcontractors(){

        //  IList<contractorviewmodel> someTypeList = new List<contractorviewmodel>();
        //    using(var context = new DB_A66DAB_accountingsheetContext())
        //    {
        //                  someTypeList = context.LoadStoredProc("dbo.getcontractors")
        //                  // .WithSqlParam("projecttype",projecttype)
        //                  // .WithSqlParam("anotherparamname",projecttype)
        //                   .ExecuteStoredProc<contractorviewmodel>();
        //    }
        //     return someTypeList;
        //  }

         public IList<taskcostrviewmodel>  gettaskcosts(){

         IList<taskcostrviewmodel> someTypeList = new List<taskcostrviewmodel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.gettaskcosts")
                         // .WithSqlParam("projecttype",projecttype)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<taskcostrviewmodel>();
           }
            return someTypeList;
         }


            public taskcostrviewmodel  gettaskcostetail(int taskcostid){

         taskcostrviewmodel _contractorviewmodel = new taskcostrviewmodel();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         _contractorviewmodel = context.LoadStoredProc("dbo.gettaskcostetail")
                         // .WithSqlParam("projecttype",projecttype)
                          .WithSqlParam("taskcostid",taskcostid)
                          .ExecuteStoredProcFirst<taskcostrviewmodel>();
           }
            return _contractorviewmodel;
         }

         public IList<taskcostprojectviewmodel>  gettaskcostmonthlyinput(int taskcostid){

         IList<taskcostprojectviewmodel> someTypeList = new List<taskcostprojectviewmodel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.gettaskcostmonthlyinput")
                          .WithSqlParam("taskcostid",taskcostid)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<taskcostprojectviewmodel>();
           }

         
            return someTypeList;
         }




    }
}
