using System;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Helper;
using System.Linq;
namespace ACCOUNTINGSHEET.Model.repositories
{
    public class MonthlyInputrepository :  RepositoryBase<Monthlyinput>
    {
       public MonthlyInputrepository(DB_A66DAB_accountingsheetContext _ctx): base(_ctx) {
            this.db=_ctx;
        } 

        
        public IList<ContractorMonthlyinputViewModel>  getcontractormonthlyinput(int contractorid){

         IList<ContractorMonthlyinputViewModel> someTypeList = new List<ContractorMonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getcontractormonthlyinput")
                          .WithSqlParam("contractorid",contractorid)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<ContractorMonthlyinputViewModel>();
           }

         
            return someTypeList;
         }


         public IList<ProjectMonthlyinputViewModel>  getprojectmonthlyinputexpense(int projectid){

         IList<ProjectMonthlyinputViewModel> someTypeList = new List<ProjectMonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getprojectmonthlyinputexpense")
                          .WithSqlParam("projectid",projectid)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<ProjectMonthlyinputViewModel>();
           }

         
            return someTypeList;
         }


         public IList<ProjectMonthlyinputViewModel>  getprojectmonthlyinputincome(int projectid){

         IList<ProjectMonthlyinputViewModel> someTypeList = new List<ProjectMonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getprojectmonthlyinputincome")
                          .WithSqlParam("projectid",projectid)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<ProjectMonthlyinputViewModel>();
           }

         
            return someTypeList;
         }


          public IList<ProjectMonthlyinputViewModel>  getmonthlyinputincome(int month,int year){
         IList<ProjectMonthlyinputViewModel> someTypeList = new List<ProjectMonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getmonthlyinputincome")
                          .WithSqlParam("month",month)
                          .WithSqlParam("year",year)
                          .ExecuteStoredProc<ProjectMonthlyinputViewModel>();
           }
            return someTypeList;
         }

          public IList<MonthlyinputViewModel>  getmonthlyinputbymonthandyear(int month,int year){
         IList<MonthlyinputViewModel> someTypeList = new List<MonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getmonthlyinputbymonthandyear")
                          .WithSqlParam("month",month)
                          .WithSqlParam("year",year)
                          .ExecuteStoredProc<MonthlyinputViewModel>();
           }
            return someTypeList;
         }

         //getmonthpreviousbalance
         public string  getmonthpreviousbalance(int month,int year){
           string res;
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         res = context.LoadStoredProc("dbo.getmonthpreviousbalance")
                          .WithSqlParam("month",month)
                          .WithSqlParam("year",year)
                          .ExecuteStoredProcWithResultOneValue<string>();
           }
            return res;
         }


        public List<Monthlyinput> FetchAllByMonthAndYear(int month ,int year)
        {
            return db.Monthlyinput.Where(d => d.Month==month && d.Year==year).ToList<Monthlyinput>();
        }


        public IList<ProjectMonthlyinputViewModel>  getprojectmonthlyinput(int projectid){

         IList<ProjectMonthlyinputViewModel> someTypeList = new List<ProjectMonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getprojectmonthlyinput")
                          .WithSqlParam("projectid",projectid)
                         // .WithSqlParam("anotherparamname",projecttype)
                          .ExecuteStoredProc<ProjectMonthlyinputViewModel>();
           }        
            return someTypeList;
         }


         //getmonthsprofits
        public IList<monthviewmodel>  getmonthsprofits(int year){
         IList<monthviewmodel> someTypeList = new List<monthviewmodel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getmonthsprofits")
                          .WithSqlParam("year",year)
                          .ExecuteStoredProc<monthviewmodel>();
           }

         
            return someTypeList;
         }

         //getmonthsprofits
        public IList<yearviewmodel>  getyears(){
         IList<yearviewmodel> someTypeList = new List<yearviewmodel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getyears")
                          .ExecuteStoredProc<yearviewmodel>();
           }
            return someTypeList;
         }

         public string  getcustomexpensesmonthpreviousbalance(int projectid,int month,int year){
           string res;
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         res = context.LoadStoredProc("dbo.getcustomexpensesmonthpreviousbalance")
                          .WithSqlParam("month",month)
                          .WithSqlParam("year",year)
                          .WithSqlParam("projectid",projectid)
                          .ExecuteStoredProcWithResultOneValue<string>();
           }
            return res;
         }


          public IList<MonthlyinputViewModel>  getmonthlyinputbymonthandyearandproject(int projectid,int month,int year){
         IList<MonthlyinputViewModel> someTypeList = new List<MonthlyinputViewModel>();
           using(var context = new DB_A66DAB_accountingsheetContext())
           {
                         someTypeList = context.LoadStoredProc("dbo.getmonthlyinputbymonthandyearandproject")
                          .WithSqlParam("month",month)
                          .WithSqlParam("year",year)
                          .WithSqlParam("projectid",projectid)
                          .ExecuteStoredProc<MonthlyinputViewModel>();
           }
            return someTypeList;
         }




    }
}
