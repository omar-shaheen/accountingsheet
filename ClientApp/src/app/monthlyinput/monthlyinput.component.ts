import { Component, OnInit } from '@angular/core';
import { project } from '../Model/project';
import { SheetService } from '../services/sheet.service';
import { contractor } from '../Model/contractor';
import { taskcost } from '../Model/taskcost';
import { monthlyinput } from '../Model/monthlyinputviewmodel';
import { mastermonthlyinput } from '../Model/mastermonthlyinput';
import { DatePipe } from '@angular/common';

const monthNames = ["يناير", "فبراير", "مارس", "ابريل", "مايو", "يونيو",
"يوليو", "اغسطس", "سبتمبر", "اكتوبر", "نوفمبر", "ديسمبر"
];
const years = ["2021", "2020", "2019", "2018", "2017", "2016",
"2022", "2023", "2024", "2025", "2025", "2026","2027", "2028","2029","2030"
];
const months = [1, 2,3,4,5,6,7,8,9,10,11,12];
@Component({
  selector: 'app-monthlyinput',
  templateUrl: './monthlyinput.component.html',
  styleUrls: ['./monthlyinput.component.css']
})
export class MonthlyinputComponent implements OnInit {
  projects:project[]=new Array;
  contractors:contractor[]=new Array;
  taskcosts:taskcost[]=new Array;
  expenses:monthlyinput[]=new Array;
  updatedexpenses:monthlyinput[]=new Array;
  deletedexpenses:monthlyinput[]=new Array;
  incomes:monthlyinput[]=new Array;
  updatedincomes:monthlyinput[]=new Array;
  deletedincomes:monthlyinput[]=new Array;
  incomesandexpenses:monthlyinput[]=new Array;
  currentmonth:number;
  currentyear:number;
  currentmonthyear:any;
  totalexpense:any=0;
  totalincome:any=0;
  balance:any=0;
  previousbalance:any=0;
  disabled:boolean=false;
  disabled2:boolean=false;
  currentmonthname:any;
  yearsearch:number;
  monthsearch:number;
   years = [2016,2017,2018,2019,2020,2021,2022, 2023, 2024, 2025, 2025, 2026,2027, 2028,2029,2030];
   months = [1, 2,3,4,5,6,7,8,9,10,11,12];
  constructor(private sheetservice:SheetService,private datepipe:DatePipe) { }

  ngOnInit(): void {
    
    this.currentmonth=(new Date().getMonth() + 1);
    this.currentyear=new Date().getFullYear();
    this.currentmonthyear = '0' + this.currentmonth.toString().slice(-2) + '/' + this.currentyear.toString()+" "+monthNames[this.currentmonth-1];
    this.getprojects();
    this.getcontractors();
    this.gettaskcosts();
    this.getmonthlyinput();
    this.getmonthpreviousbalance();
    this.setdates();
  }
  setdates(){
    var day=new Date().getDate();
    console.log(day);
    var date=this.currentmonth+'-'+day+'-'+this.currentyear;
    this.createdat=this.conertdate(date);
    this.incomecreatedat=this.conertdate(date);
    this.monthsearch=this.currentmonth;
    this.yearsearch=this.currentyear;
  }
  getmonthlyinput(){
    this.incomesandexpenses=[];
    this.incomes=[];
    this.expenses=[];
    this.totalexpense=0;
    this.totalincome=0;
    this.balance=0;
    this.sheetservice.getmonthlyinput(this.currentmonth,this.currentyear).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.incomesandexpenses=res.data;
        console.log('getmonthlyinput',res);
        this.expenses=this.incomesandexpenses.filter(x=>x.inputtype==1);
        this.incomes=this.incomesandexpenses.filter(x=>x.inputtype==2);
        this.expenses.forEach(element => {
          this.totalexpense=this.totalexpense+element.expenseamount;
        });
        this.incomes.forEach(element => {
          this.totalincome=this.totalincome+element.incomeamount;
        });
        this.balance= this.totalincome-this.totalexpense;
      }
      }, 
      error => console.error(error));
  }
  getprojects(){
    this.sheetservice.getprojects().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.projects=res.data;
      }
      }, 
      error => console.error(error));
  }
  getcontractors(){
    this.sheetservice.getcontractors().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.contractors=res.data;
      }
      }, 
      error => console.error(error));
  }
  gettaskcosts(){
    this.sheetservice.gettaskcosts().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.taskcosts=res.data;
      }
      }, 
      error => console.error(error));
  }
  getmonthpreviousbalance(){
    this.previousbalance=0;
    this.sheetservice.getmonthpreviousbalance(this.currentmonth,this.currentyear).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('previous balance',res.data)
        this.previousbalance=Number(res.data);
        this.totalincome=this.totalincome+this.previousbalance;
        this.balance=this.balance+this.previousbalance;
      }
      }, 
      error => console.error(error));
  }
  id:any;
expenseamount:any;
description:any;
taskcostid:any;
projectid:any;
contractorid:any;
createdat:any;
notes:any;
taskcostname:any;
projectname:any;
contractorname:any;
currentindex:any=-1;
currentitemid:any=0;
  additemexpense(id,expenseamount,description,taskcostid,projectid,contractorid,createdat,notes){
     var proj=this.projects.find(x=>x.id== projectid);
     var taskc=this.taskcosts.find(x=>x.id== taskcostid);
     var contr=this.contractors.find(x=>x.id== contractorid);
     var _monthlyinputviewmodel=new monthlyinput();
     _monthlyinputviewmodel.id=id;
     _monthlyinputviewmodel.expenseamount=Number(expenseamount);
     _monthlyinputviewmodel.description=description;
     _monthlyinputviewmodel.taskcostid=Number(taskcostid);
     _monthlyinputviewmodel.projectid=Number(projectid);
     _monthlyinputviewmodel.contractorid=Number(contractorid);
    
     _monthlyinputviewmodel.createdat= this.conertdate(createdat);
     _monthlyinputviewmodel.notes=notes;
     _monthlyinputviewmodel.taskcostname=taskc!=null?taskc.name:"";
     _monthlyinputviewmodel.projectname=proj!=null?proj.name:"";
    _monthlyinputviewmodel.contractorname=contr!=null?contr.name:"";
    _monthlyinputviewmodel.flagechange=true;
    _monthlyinputviewmodel.inputtype=1;
    _monthlyinputviewmodel.month=this.currentmonth;
    _monthlyinputviewmodel.year=this.currentyear;
     if(this.currentindex>-1){ 
      //this.expenses[this.currentindex]=_monthlyinputviewmodel;
      this.addmonthlyinput(_monthlyinputviewmodel);
     }else{
     // this.expenses.push(_monthlyinputviewmodel);
      this.addmonthlyinput(_monthlyinputviewmodel);
     }
     

     this.resetform();
     
  }
  resetform(){
    this.currentindex=-1;
    this.currentitemid=0;
    this.expenseamount=undefined;
    this.description=undefined;
    this.taskcostid=undefined;
    this.projectid=undefined;
    this.contractorid=undefined;
    this.createdat=undefined;
    this.notes=undefined;
  }

  
  rowElim(item:monthlyinput){
    if(item!=null){     
     // const index: number = this.expenses.indexOf(item);
    //  if (index !== -1) {
        //  this.expenses.splice(index, 1);
        //  if(item.id>0){
        //   this.deletedexpenses.push(item);
        //   }
        this.sheetservice.deletemonthlyinput(item.id).subscribe(res => {    
          if(res!=null && res.code=="999"){
            console.log('dataupdatedsuccessfully');
          }else{
            console.log('error found');
          }
          this.getmonthlyinput();
          this.disabled=false;
          }, 
          error => console.error(error));
      // }        
     }
  }


  rowEdit(item:monthlyinput){
    if(item!=null){
      this.currentitemid = item.id;
      this.expenseamount=item.expenseamount;
      this.description=item.description;
      this.taskcostid=item.taskcostid;
      this.projectid=item.projectid;
      this.contractorid=item.contractorid;
      this.createdat=item.createdat;
      this.notes=item.notes;
      this.currentindex = this.expenses.indexOf(item);
    }
    
  }

  incomeamount:any;
  incomedescription:any;
  incomeprojectid:any;
  incomecreatedat:any;
  incomecurrentindex:any=-1;
  incomecurrentitemid:any=0;

  additemincome(id,incomeamount,incomedescription,incomeprojectid,incomecreatedat){
    var proj=this.projects.find(x=>x.id== incomeprojectid);
    var _monthlyinputviewmodel=new monthlyinput();
    _monthlyinputviewmodel.id=id;
    _monthlyinputviewmodel.incomeamount=Number(incomeamount);
    _monthlyinputviewmodel.description=incomedescription;
    _monthlyinputviewmodel.projectid=Number(incomeprojectid);
    _monthlyinputviewmodel.createdat=this.conertdate(incomecreatedat);
    _monthlyinputviewmodel.projectname=proj!=null?proj.name:"";
    _monthlyinputviewmodel.flagechange=true;
    _monthlyinputviewmodel.inputtype=2;
    _monthlyinputviewmodel.month=this.currentmonth;
    _monthlyinputviewmodel.year=this.currentyear;
    if(this.incomecurrentindex>-1){ 
     //this.incomes[this.incomecurrentindex]=_monthlyinputviewmodel;
     this.addmonthlyinput(_monthlyinputviewmodel);
    }else{
     //this.incomes.push(_monthlyinputviewmodel);
     this.addmonthlyinput(_monthlyinputviewmodel);
    }
    

    this.incomeresetform();
    
 }

 addmonthlyinput(_monthlyinputviewmodel:monthlyinput){
   console.log('_monthlyinputviewmodel',_monthlyinputviewmodel);
  this.sheetservice.addmonthlyinput(_monthlyinputviewmodel).subscribe(res => {    
    if(res!=null && res.code=="999"){
      console.log('dataupdatedsuccessfully');
    }else{
      console.log('error found');
    }
    this.getmonthlyinput();
    this.disabled=false;
    }, 
    error => console.error(error));
 }
 incomeresetform(){
   this.incomecurrentindex=-1;
   this.incomecurrentitemid=0;
   this.incomeamount=undefined;
   this.incomedescription=undefined;
   this.incomeprojectid=undefined;
   this.incomecreatedat=undefined;
 }

 
 rowElimincome(item:monthlyinput){
   if(item!=null){     
     const index: number = this.incomes.indexOf(item);
     if (index !== -1) {
        this.incomes.splice(index, 1);
        if(item.id>0){
          this.deletedexpenses.push(item);
        }
      }        
    }
 }


 rowEditincom(item:monthlyinput){
   if(item!=null){
     this.incomecurrentitemid = item.id;
     this.incomeamount=item.incomeamount;
     this.incomedescription=item.description;
     this.incomeprojectid=item.projectid;
     this.incomecreatedat=item.createdat;
     this.incomecurrentindex = this.incomes.indexOf(item);
   }
   
 }






  submitchanges(){
    this.disabled=true;
    this.updatedexpenses=[];
    var _model=new   mastermonthlyinput();
    this.expenses.forEach(element => {
      if(element.flagechange){
        this.updatedexpenses.push(element);
      }
    });
    _model.expenses=this.updatedexpenses;
    _model.deletedexpenses=this.deletedexpenses;
    _model.currentmonth=this.currentmonth;
    _model.currentyear=this.currentyear;
    console.log(_model);
    if(_model.expenses.length>0){
     this.sheetservice.submitchangesexpenseincome(_model).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getmonthlyinput();
      this.disabled=false;
      }, 
      error => console.error(error));
      }
  }
  submitchangesincome(){
    this.disabled2=true;
    this.updatedincomes=[];
  var _model=new   mastermonthlyinput();
  this.incomes.forEach(element => {
    if(element.flagechange){
      this.updatedincomes.push(element);
    }
  });
  _model.incomes=this.updatedincomes;
  _model.deletedincomes=this.deletedincomes; 
  _model.currentmonth=this.currentmonth;
  _model.currentyear=this.currentyear;
  console.log(_model);
  if(_model.incomes.length>0){
   this.sheetservice.submitchangesexpenseincome(_model).subscribe(res => {    
    if(res!=null && res.code=="999"){
      console.log('dataupdatedsuccessfully');
    }else{
      console.log('error found');
    }
    this.getmonthlyinput();
    this.disabled2=false;
    }, 
    error => console.error(error));
    }
  }

     dateParts:any[]=[];
      changeStoreFormate(dt:any){
        
    // ////debugger;
       // date format
       if(dt!=null&& dt!=''){
        this.dateParts=[];
        this.dateParts=dt.split('-');
        dt='';
        
        dt=this.dateParts[2]+'/'+this.dateParts[1]+'/'+this.dateParts[0];
        
       }
       
       return dt;
       
    }


    refreshpage(){
      
    }
    getpreviousmonth(){
      
      if(this.currentmonth==1){
        this.currentmonth=12;
        this.currentyear=this.currentyear-1;
      }else{
        this.currentmonth=this.currentmonth-1;
      }
      this.currentmonthyear = '0' + this.currentmonth.toString().slice(-2) + '/' + this.currentyear.toString()+" "+monthNames[this.currentmonth-1];
      this.getprojects();
      this.getcontractors();
      this.gettaskcosts();
      this.getmonthlyinput();
      this.getmonthpreviousbalance();
      this.setdates();
    }
    getnextmonth(){
     
      if(this.currentmonth==12){
        this.currentmonth=1;
        this.currentyear=this.currentyear+1;
      }else{
        this.currentmonth=this.currentmonth+1;
      }
      this.currentmonthyear = '0' + this.currentmonth.toString().slice(-2) + '/' + this.currentyear.toString()+" "+monthNames[this.currentmonth-1];
      this.getprojects();
      this.getcontractors();
      this.gettaskcosts();
      this.getmonthlyinput();
      this.getmonthpreviousbalance();
      this.setdates();
    }

     conertdate(dt:any){
       if(dt!=null && dt !='' && dt !=undefined){
        var date = new  Date (dt);
        //console.log(date.toDateString());
        var date1=date.toDateString();
        var datef= this.datepipe.transform(date1, 'yyyy-MM-dd');
       // console.log(datef);
        return datef;
       }
     
     }


changemonthyear(){
  this.currentmonth=this.monthsearch;
  this.currentyear=this.yearsearch;
  this.getprojects();
  this.getcontractors();
  this.gettaskcosts();
  this.getmonthlyinput();
  this.getmonthpreviousbalance();
  this.setdates();
}




}
