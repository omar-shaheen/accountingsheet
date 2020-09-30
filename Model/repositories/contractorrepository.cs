using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Helper;

namespace ACCOUNTINGSHEET.Model.repositories
{
    public class contractorrepository :  RepositoryBase<Contractor>
    {
       public contractorrepository(DB_A66DAB_accountingsheetContext _ctx): base(_ctx) {
            this.db=_ctx;
        } 

        
        public IList<contractorviewmodel>  getcontractors(){

         IList<contractorviewmodel> someTypeList = new List<contractorviewmodel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getcontractors")
                         // .WithSqlParam("projecttype",projecttype)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<contractorviewmodel>();
           }
            return someTypeList;
         }

          public contractorviewmodel  getcontractordetail(int contractorid){

         contractorviewmodel _contractorviewmodel = new contractorviewmodel();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         _contractorviewmodel = context.LoadStoredProc("dbo.getcontractordetail")
                         // .WithSqlParam("projecttype",projecttype)
                          .WithSqlParam("contractorid",contractorid)
                          .ExecuteStoredProcFirst<contractorviewmodel>();
           }
            return _contractorviewmodel;
         }

        



    }
}
