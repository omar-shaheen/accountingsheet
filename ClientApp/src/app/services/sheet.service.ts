import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders,HttpParams } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { responsedata } from '../Model/ResponseData';
import { mastermonthlyinput } from '../Model/mastermonthlyinput';
import { masterproject } from '../Model/masterproject';
import { mastercontractor } from '../Model/mastercontractor';
import { mastertaskcost } from '../Model/mastertaskcost';
import { monthlyinput } from '../Model/monthlyinputviewmodel';
import { project } from '../Model/project';
import { contractor } from '../Model/contractor';
import { taskcost } from '../Model/taskcost';
@Injectable()
export class SheetService {

  public wepapiurl: string;
  reqHeader = new HttpHeaders({
    'No-Auth': 'True'
  });
  public token: String;
  constructor(private http: HttpClient) {
   //this.wepapiurl="http://ahmedderbala1991-001-site1.ctempurl.com/api/";
   this.wepapiurl="https://localhost:5001/api/";
  }
  


  getprojects()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getprojects',{headers:this.reqHeader});
  }
  fetchprojects()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/fetchprojects',{headers:this.reqHeader});
  } 
  getcontractors()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getcontractors',{headers:this.reqHeader});
  }
  getListcontractors()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getListcontractors',{headers:this.reqHeader});
  }
  
  getListtaskcosts()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getListtaskcosts',{headers:this.reqHeader});
  }
  gettaskcosts()
  {
    // let params = new HttpParams();
    // params = params.append('lang',lang);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/gettaskcosts',{headers:this.reqHeader});
  } 
  //getmonthpreviousbalance
  submitchangesexpenseincome(_mastermonthlyinput:mastermonthlyinput)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/submitchangesexpenseincome',_mastermonthlyinput,{headers:this.reqHeader});
  }
  addmonthlyinput(_mastermonthlyinput:monthlyinput)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/addmonthlyinput',_mastermonthlyinput,{headers:this.reqHeader});
  }
  //saveprojectschanges
  suubmitprojects(_mastermonthlyinput:masterproject)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/suubmitprojects',_mastermonthlyinput,{headers:this.reqHeader});
  }

  
  suubmittaskcostss(_mastermonthlyinput:mastertaskcost)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/suubmittaskcostss',_mastermonthlyinput,{headers:this.reqHeader});
  }
  getmonthlyinput(month:any,year:any)
  {
     let params = new HttpParams();
     params = params.append('month',month);
     params = params.append('year',year);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getmonthlyinput',{headers:this.reqHeader,params:params});
  } 

  // /deletemonthlyinput
  deletemonthlyinput( monthlyinputid:any)
  {
     let params = new HttpParams();
     params = params.append('monthlyinputid',monthlyinputid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/deletemonthlyinput',{headers:this.reqHeader,params:params});
  } 

   deleteproject( projectid:any)
  {
     let params = new HttpParams();
     params = params.append('projectid',projectid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/deleteproject',{headers:this.reqHeader,params:params});
  } 

  //getprojectmonthlyinput
  getprojectmonthlyinput(projectid:any)
  {
     let params = new HttpParams();
     params = params.append('projectid',projectid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getprojectmonthlyinput',{headers:this.reqHeader,params:params});
  } 

  getmonthpreviousbalance(month:any,year:any)
  {
     let params = new HttpParams();
     params = params.append('month',month);
     params = params.append('year',year);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getmonthpreviousbalance',{headers:this.reqHeader,params:params});
  } 

  getprojectbyid(projectid:any)
  {
     let params = new HttpParams();
     params = params.append('projectid',projectid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getprojectbyid',{headers:this.reqHeader,params:params});
  } 

  getmonthsprofits(year:any)
  {
     let params = new HttpParams();
     params = params.append('year',year);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getmonthsprofits',{headers:this.reqHeader,params:params});
  } 

  getyears(){
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getyears',{headers:this.reqHeader});
  }


  getcontractormonthlyinput(contractorid:any)
  {
     let params = new HttpParams();
     params = params.append('contractorid',contractorid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getcontractormonthlyinput',{headers:this.reqHeader,params:params});
  } 

  getcontractordetail(contractorid:any){
    let params = new HttpParams();
    params = params.append('contractorid',contractorid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getcontractordetail',{headers:this.reqHeader,params:params});
  }
  gettaskcostmonthlyinput(taskcostid:any)
  {
     let params = new HttpParams();
     params = params.append('taskcostid',taskcostid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/gettaskcostmonthlyinput',{headers:this.reqHeader,params:params});
  } 
  suubmitcontractorss(_mastercontractor:mastercontractor)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/suubmitcontractorss',_mastercontractor,{headers:this.reqHeader});
  }

  gettaskcostetail(taskcostid:any){
    let params = new HttpParams();
    params = params.append('taskcostid',taskcostid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/gettaskcostetail',{headers:this.reqHeader,params:params});
  }




  getcustomexpensesmonthlyinput(projectid:any,month:any,year:any)
  {
     let params = new HttpParams();
     params = params.append('projectid',projectid);
     params = params.append('month',month);
     params = params.append('year',year);
     
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getcustomexpensesmonthlyinput',{headers:this.reqHeader,params:params});
  } 

  

  getcustomexpensesmonthpreviousbalance(projectid:any,month:any,year:any)
  {
     let params = new HttpParams();
     params = params.append('projectid',projectid);
     params = params.append('month',month);
     params = params.append('year',year);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/getcustomexpensesmonthpreviousbalance',{headers:this.reqHeader,params:params});
  } 

  //getcustomexpensesmonthpreviousbalance //getcustomexpensesmonthlyinput submitchangescustomexpenses

  addproject(_project:project)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/addproject',_project,{headers:this.reqHeader});
  }

  addcontractor(_contractor:contractor)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/addcontractor',_contractor,{headers:this.reqHeader});
  }

  addtaskcost(_taskcost:taskcost)
  {
    return this.http.post<responsedata>(this.wepapiurl+'Sheet/addtaskcost',_taskcost,{headers:this.reqHeader});
  }


  deletecontractor( contractorid:any)
  {
     let params = new HttpParams();
     params = params.append('contractorid',contractorid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/deletecontractor',{headers:this.reqHeader,params:params});
  } 

  deletetaskcost( taskcostid:any)
  {
     let params = new HttpParams();
     params = params.append('taskcostid',taskcostid);
    return this.http.get<responsedata>(this.wepapiurl+'Sheet/deletetaskcost',{headers:this.reqHeader,params:params});
  } 
}
