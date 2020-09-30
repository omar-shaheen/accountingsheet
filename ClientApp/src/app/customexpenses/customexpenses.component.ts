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
@Component({
  selector: 'app-customexpenses',
  templateUrl: './customexpenses.component.html',
  styleUrls: ['./customexpenses.component.css']
})
export class CustomexpensesComponent implements OnInit {
  contractors:contractor[]=new Array;
  taskcosts:taskcost[]=new Array;
  expenses:monthlyinput[]=new Array;
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
  disabled2:boolean=false;

  yearsearch:number;
  monthsearch:number;
   years = [2016,2017,2018,2019,2020,2021,2022, 2023, 2024, 2025, 2025, 2026,2027, 2028,2029,2030];
   months = [1, 2,3,4,5,6,7,8,9,10,11,12];
  constructor(private sheetservice:SheetService,private datepipe:DatePipe) { }

  ngOnInit(): void {
    this.currentmonth=(new Date().getMonth() + 1);
    this.currentyear=new Date().getFullYear();
    this.currentmonthyear = '0' + this.currentmonth.toString().slice(-2) + '/' + this.currentyear.toString()+" "+monthNames[this.currentmonth-1];
    this.getmonthlyinput();
    this.getmonthpreviousbalance();
    this.setdates();
  }
  getmonthlyinput(){
    this.incomesandexpenses=[];
    this.incomes=[];
    this.expenses=[];
    this.totalexpense=0;
    this.totalincome=0;
    this.balance=0;
    this.sheetservice.getcustomexpensesmonthlyinput(3,this.currentmonth,this.currentyear).subscribe(res => {    
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


  incomeamount:any;
  incomedescription:any;
  incomecreatedat:any;
  incomecurrentindex:any=-1;
  incomecurrentitemid:any=0;

  additemincome(id,incomeamount,incomedescription,incomecreatedat){
    var _monthlyinputviewmodel=new monthlyinput();
    _monthlyinputviewmodel.id=id;
    _monthlyinputviewmodel.incomeamount=Number(incomeamount);
    _monthlyinputviewmodel.description=incomedescription;
    _monthlyinputviewmodel.projectid=3;
    _monthlyinputviewmodel.createdat=this.conertdate(incomecreatedat);
    _monthlyinputviewmodel.flagechange=true;
    _monthlyinputviewmodel.inputtype=2;
    _monthlyinputviewmodel.month=this.currentmonth;
    _monthlyinputviewmodel.year=this.currentyear;
    if(this.incomecurrentindex>-1){ 
     //this.incomes[this.incomecurrentindex]=_monthlyinputviewmodel;
     this.addmonthlyinput(_monthlyinputviewmodel);
    }else{
    // this.incomes.push(_monthlyinputviewmodel);
     this.addmonthlyinput(_monthlyinputviewmodel);
    }
    

    this.incomeresetform();
    
 }
 incomeresetform(){
   this.incomecurrentindex=-1;
   this.incomecurrentitemid=0;
   this.incomeamount=undefined;
   this.incomedescription=undefined;
   this.incomecreatedat=undefined;
 }

 
 rowElimincome(item:monthlyinput){
   if(item!=null){     
    this.sheetservice.deletemonthlyinput(item.id).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getmonthlyinput();
      }, 
      error => console.error(error));        
    }
 }


 rowEditincom(item:monthlyinput){
   if(item!=null){
     this.incomecurrentitemid = item.id;
     this.incomeamount=item.incomeamount;
     this.incomedescription=item.description;
     this.incomecreatedat=item.createdat;
     this.incomecurrentindex = this.incomes.indexOf(item);
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
      this.getmonthlyinput();
      this.getmonthpreviousbalance();
      this.setdates();
    }


    conertdate(dt:any){
      var date = new  Date (dt);
      //console.log(date.toDateString());
      var date1=date.toDateString();
      var datef= this.datepipe.transform(date1, 'yyyy-MM-dd');
     // console.log(datef);
      return datef;
     }

     
changemonthyear(){
  this.currentmonth=this.monthsearch;
  this.currentyear=this.yearsearch;
  this.getmonthlyinput();
  this.getmonthpreviousbalance();
  this.setdates();
}
setdates(){
  var day=new Date().getDate();
  console.log(day);
  var date=this.currentmonth+'-'+day+'-'+this.currentyear;
  this.incomecreatedat=this.conertdate(date);
  this.monthsearch=this.currentmonth;
  this.yearsearch=this.currentyear;
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
   }, 
   error => console.error(error));
}



}
