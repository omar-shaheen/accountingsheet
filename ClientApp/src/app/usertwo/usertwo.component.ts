import { Component, OnInit } from '@angular/core';
import { monthlyinput } from '../Model/monthlyinputviewmodel';
import { SheetService } from '../services/sheet.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-usertwo',
  templateUrl: './usertwo.component.html',
  styleUrls: ['./usertwo.component.css']
})
export class UsertwoComponent implements OnInit {


  expenses:monthlyinput[]=new Array;
  incomes:monthlyinput[]=new Array;
  incomesandexpenses:monthlyinput[]=new Array;
  totalexpense:any=0;
  totalincome:any=0;
  balance:any=0;
  projectid:any=0;
  projectname:any;
  constructor(private route: ActivatedRoute,private sheetservice:SheetService,private datepipe:DatePipe) { }

  ngOnInit(): void {
      this.projectid = 2;
    this.getmonthlyinput();
    this.getprojectbyid();
  }
  getprojectbyid(){
    this.sheetservice.getprojectmonthlyinput(this.projectid).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.projectname=res.data.name;
      }
      }, 
      error => console.error(error));
  }
  getmonthlyinput(){
    this.incomesandexpenses=[];
    this.incomes=[];
    this.expenses=[];
    this.totalexpense=0;
    this.totalincome=0;
    this.balance=0;
    this.sheetservice.getprojectmonthlyinput(this.projectid).subscribe(res => {    
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
}
