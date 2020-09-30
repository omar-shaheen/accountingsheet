import { Component, OnInit } from '@angular/core';
import { monthlyinput } from '../Model/monthlyinputviewmodel';
import { SheetService } from '../services/sheet.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-taskcostdetail',
  templateUrl: './taskcostdetail.component.html',
  styleUrls: ['./taskcostdetail.component.css']
})
export class TaskcostdetailComponent implements OnInit {
  expenses:monthlyinput[]=new Array;
  incomesandexpenses:monthlyinput[]=new Array;
  totalexpense:any=0;
  totalincome:any=0;
  balance:any=0;
  taskcostid:any=0;
  taskcostname:any;
  constructor(private route: ActivatedRoute,private sheetservice:SheetService,private datepipe:DatePipe) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.taskcostid = params.get('id');
    });
    this.gettaskcostmonthlyinput();
    this.gettaskcostetail();
  }
  gettaskcostetail(){
    this.sheetservice.gettaskcostetail(this.taskcostid).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.taskcostname=res.data.name;
      }
      }, 
      error => console.error(error));
  }
  gettaskcostmonthlyinput(){
    this.incomesandexpenses=[];
    this.expenses=[];
    this.totalexpense=0;
    this.totalincome=0;
    this.balance=0;
    this.sheetservice.gettaskcostmonthlyinput(this.taskcostid).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.incomesandexpenses=res.data;
        console.log('getmonthlyinput',res);
        this.expenses=this.incomesandexpenses;
        this.expenses.forEach(element => {
          this.totalexpense=this.totalexpense+element.expenseamount;
        });
      }
      }, 
      error => console.error(error));
  }
}
