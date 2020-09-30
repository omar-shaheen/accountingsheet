using System;
using Microsoft.AspNetCore.Mvc;
using ACCOUNTINGSHEET.Model;
using ACCOUNTINGSHEET.Model.repositories;
using AutoMapper;
using System.Collections.Generic;
using ACCOUNTINGSHEET.Helper;
using System.Linq;
namespace ACCOUNTINGSHEET.Controllers
{

     [Route("api/[controller]")]
    public class SheetController: Controller
    {
          private UnitOfWork unitOfWork = new UnitOfWork();
          private readonly IMapper _mapper;
          public SheetController(IMapper mapper)
          {
             _mapper = mapper;
          }

         
         


         [HttpGet("[action]")]
          public ResponseData getcontractordetail(int contractorid){
              var res=unitOfWork.contractorrepository.getcontractordetail(contractorid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }

          //gettaskcostetail
         [HttpGet("[action]")]
          public ResponseData gettaskcostetail(int taskcostid){
              var res=unitOfWork.taskcostsrepository.gettaskcostetail(taskcostid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }
          
          [HttpGet("[action]")]
          public ResponseData getcontractormonthlyinput(int contractorid){
              var res=unitOfWork.MonthlyInputrepository.getcontractormonthlyinput(contractorid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }

           [HttpGet("[action]")]
          public ResponseData gettaskcostmonthlyinput(int taskcostid){
              var res=unitOfWork.taskcostsrepository.gettaskcostmonthlyinput(taskcostid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }
         

          [HttpGet("[action]")]
          public ResponseData getprojectmonthlyinput(int projectid){
              var res=unitOfWork.MonthlyInputrepository.getprojectmonthlyinput(projectid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }

           [HttpGet("[action]")]
          public ResponseData getprojectbyid(int projectid){
              var res=unitOfWork.Projectrepository.GetById(projectid);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             };                 
          }

          [HttpGet("[action]")]   
          public ResponseData fetchprojects(){
             var res=unitOfWork.Projectrepository.getprojects(4);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
          }


         [HttpGet("[action]")]
         public ResponseData getprojects()
         {
             var res=unitOfWork.Projectrepository.GetAll();
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

         [HttpGet("[action]")]
         public ResponseData getcontractors()
         {
             var res=unitOfWork.contractorrepository.GetAll();
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

         [HttpGet("[action]")]
         public ResponseData gettaskcosts()
         {
             var res=unitOfWork.taskcostsrepository.GetAll();
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

         [HttpGet("[action]")]
         public ResponseData getmonthlyinput(int month,int year)
         {
             var res=unitOfWork.MonthlyInputrepository.getmonthlyinputbymonthandyear(month,year);
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

         [HttpGet("[action]")]
         public ResponseData getmonthpreviousbalance(int month,int year)
         {
             var res=unitOfWork.MonthlyInputrepository.getmonthpreviousbalance(month,year);
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

        [Route("submitchangesexpenseincome")] 
        public ResponseData submitchangesexpenseincome([FromBody]mastermonthlyinput _mastermonthlyinput){
              if(_mastermonthlyinput==null){
                  return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
                   }; 
               }
               //delete if not found in comming array
               foreach (var item in _mastermonthlyinput.Deletedincomes)
               {
                       unitOfWork.MonthlyInputrepository.Delete(item.Id);
                       unitOfWork.Commit();
               }
               foreach (var item in _mastermonthlyinput.Deletedexpenses)
               {
                       unitOfWork.MonthlyInputrepository.Delete(item.Id);
                       unitOfWork.Commit();
               }
               foreach (var item in _mastermonthlyinput.Incomes)
               {
                   if(item.Id>0){
                       var _itemupdate=unitOfWork.MonthlyInputrepository.GetById(item.Id);
                       if(_itemupdate!=null){
                           item.Inputtype=2;
                           item.Month=_mastermonthlyinput.Currentmonth;
                           item.Year=_mastermonthlyinput.Currentyear;
                           unitOfWork.MonthlyInputrepository.Update(item,item.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         item.Inputtype=2;
                         item.Month=_mastermonthlyinput.Currentmonth;
                         item.Year=_mastermonthlyinput.Currentyear;
                         unitOfWork.MonthlyInputrepository.Add(item);
                         unitOfWork.Commit();
                   } 
               }
               foreach (var item in _mastermonthlyinput.Expenses)
               {
                   if(item.Id>0){
                       var _itemupdate=unitOfWork.MonthlyInputrepository.GetById(item.Id);
                       if(_itemupdate!=null){
                           item.Inputtype=1;
                           item.Month=_mastermonthlyinput.Currentmonth;
                           item.Year=_mastermonthlyinput.Currentyear;
                           unitOfWork.MonthlyInputrepository.Update(item,item.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         item.Inputtype=1;
                         item.Month=_mastermonthlyinput.Currentmonth;
                         item.Year=_mastermonthlyinput.Currentyear;
                         unitOfWork.MonthlyInputrepository.Add(item);
                         unitOfWork.Commit();
                   } 
               }
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
          }
          
       [Route("addmonthlyinput")] 
        public ResponseData addmonthlyinput([FromBody]Monthlyinput _Monthlyinput){
              if(_Monthlyinput!=null){
                  if(_Monthlyinput.Id>0){
                       var _itemupdate=unitOfWork.MonthlyInputrepository.GetById(_Monthlyinput.Id);
                       if(_itemupdate!=null){
                           unitOfWork.MonthlyInputrepository.Update(_Monthlyinput,_Monthlyinput.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.MonthlyInputrepository.Add(_Monthlyinput);
                         unitOfWork.Commit();
                   } 
                   return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
                 }; 
              }
              return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
              }; 
        }
        [Route("deletemonthlyinput")] 
        public ResponseData deletemonthlyinput(int monthlyinputid){
             unitOfWork.MonthlyInputrepository.Delete(monthlyinputid);
             unitOfWork.Commit();
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
        }
        [Route("suubmitprojects")] 
        public ResponseData suubmitprojects([FromBody]masterproject _masterproject){
              if(_masterproject==null){
                  return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
                   }; 
               }
               //delete if  found in comming deleted array
               foreach (var item in _masterproject.Deletedprojects)
               {    
                       unitOfWork.Projectrepository.Delete(item.Id);
                       unitOfWork.Commit();
               }
               foreach (var item in _masterproject.Projects)
               {
                   if(item.Id>0){
                       var _itemupdate=unitOfWork.Projectrepository.GetById(item.Id);
                       if(_itemupdate!=null){
                           _itemupdate.Name=item.Name;
                           unitOfWork.Projectrepository.Update(_itemupdate,_itemupdate.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         item.Type=4;
                         unitOfWork.Projectrepository.Add(item);
                         unitOfWork.Commit();
                   } 
               }
               
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
          }

         

         [Route("addproject")] 
        public ResponseData addproject([FromBody]Project _Project){
              if(_Project!=null){
                  if(_Project.Id>0){
                       var _itemupdate=unitOfWork.Projectrepository.GetById(_Project.Id);
                       if(_itemupdate!=null){
                           unitOfWork.Projectrepository.Update(_Project,_Project.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.Projectrepository.Add(_Project);
                         unitOfWork.Commit();
                   } 
                   return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
                 }; 
              }
              return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
              }; 
        }
       [Route("deleteproject")] 
        public ResponseData deleteproject(int projectid){
             unitOfWork.Projectrepository.Delete(projectid);
             unitOfWork.Commit();
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
        }
          

         
         

          [HttpGet("[action]")]   
          public ResponseData getmonthsprofits(int year){
             var res=unitOfWork.MonthlyInputrepository.getmonthsprofits(year);
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
          }


          
          [HttpGet("[action]")]   
          public ResponseData getyears(){
             var res=unitOfWork.MonthlyInputrepository.getyears();
              return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
          }


           [HttpGet("[action]")]
         public ResponseData getListcontractors()
         {
             var res=unitOfWork.contractorrepository.getcontractors();
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }


         //suubmitcontractorss
         [Route("suubmitcontractorss")] 
        public ResponseData suubmitcontractorss([FromBody]mastercontractor _mastercontractor){
              if(_mastercontractor==null){
                  return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
                   }; 
               }
               //delete if  found in comming deleted array
               foreach (var item in _mastercontractor.Deletedcontractors)
               {    
                       unitOfWork.contractorrepository.Delete(item.Id);
                       unitOfWork.Commit();
               }
               foreach (var item in _mastercontractor.Contractors)
               {
                   if(item.Id>0){
                       var _itemupdate=unitOfWork.contractorrepository.GetById(item.Id);
                       if(_itemupdate!=null){
                           _itemupdate.Name=item.Name;
                           unitOfWork.contractorrepository.Update(_itemupdate,_itemupdate.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.contractorrepository.Add(item);
                         unitOfWork.Commit();
                   } 
               }
               
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
          }


           [HttpGet("[action]")]
         public ResponseData getcustomexpensesmonthpreviousbalance(int projectid,int month,int year)
         {
             var res=unitOfWork.MonthlyInputrepository.getcustomexpensesmonthpreviousbalance(projectid,month,year);
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }


         [HttpGet("[action]")]
         public ResponseData getcustomexpensesmonthlyinput(int projectid,int month,int year)
         {
             var res=unitOfWork.MonthlyInputrepository.getmonthlyinputbymonthandyearandproject(projectid,month,year);
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }

        // submitchangescustomexpenses

          //suubmittaskcostss
         [Route("suubmittaskcostss")] 
        public ResponseData suubmittaskcostss([FromBody]mastertaskcost _mastertaskcost){
              if(_mastertaskcost==null){
                  return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
                   }; 
               }
               //delete if  found in comming deleted array
               foreach (var item in _mastertaskcost.Deletedtaskcosts)
               {    
                       unitOfWork.taskcostsrepository.Delete(item.Id);
                       unitOfWork.Commit();
               }
               foreach (var item in _mastertaskcost.Taskcosts)
               {
                   if(item.Id>0){
                       var _itemupdate=unitOfWork.taskcostsrepository.GetById(item.Id);
                       if(_itemupdate!=null){
                           _itemupdate.Name=item.Name;
                           unitOfWork.taskcostsrepository.Update(_itemupdate,_itemupdate.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.taskcostsrepository.Add(item);
                         unitOfWork.Commit();
                   } 
               }
               
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
          }


             [HttpGet("[action]")]
         public ResponseData getListtaskcosts()
         {
             var res=unitOfWork.taskcostsrepository.gettaskcosts();
             return new ResponseData{
                 Code="999",
                 Message="OK",
                 Data=res,
             }; 
         }



           [Route("addcontractor")] 
        public ResponseData addcontractor([FromBody]Contractor _Contractor){
              if(_Contractor!=null){
                  if(_Contractor.Id>0){
                       var _itemupdate=unitOfWork.contractorrepository.GetById(_Contractor.Id);
                       if(_itemupdate!=null){
                           unitOfWork.contractorrepository.Update(_Contractor,_Contractor.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.contractorrepository.Add(_Contractor);
                         unitOfWork.Commit();
                   } 
                   return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
                 }; 
              }
              return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
              }; 
        }
       [Route("deletecontractor")] 
        public ResponseData deletecontractor(int contractorid){
             unitOfWork.contractorrepository.Delete(contractorid);
             unitOfWork.Commit();
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
        }



          [Route("addtaskcost")] 
        public ResponseData addtaskcost([FromBody]Taskcost _Taskcost){
              if(_Taskcost!=null){
                  if(_Taskcost.Id>0){
                       var _itemupdate=unitOfWork.taskcostsrepository.GetById(_Taskcost.Id);
                       if(_itemupdate!=null){
                           unitOfWork.taskcostsrepository.Update(_Taskcost,_Taskcost.Id);
                           unitOfWork.Commit();
                       }
                   }else{
                         unitOfWork.taskcostsrepository.Add(_Taskcost);
                         unitOfWork.Commit();
                   } 
                   return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
                 }; 
              }
              return new ResponseData{
                        Code="904",
                        Message="Bad Request",
                        Data=null,
              }; 
        }
       [Route("deletetaskcost")] 
        public ResponseData deletetaskcost(int taskcostid){
             unitOfWork.taskcostsrepository.Delete(taskcostid);
             unitOfWork.Commit();
              return new ResponseData{
                        Code="999",
                        Message="OK",
                        Data=null,
              }; 
        }

          
          
         
    }
}