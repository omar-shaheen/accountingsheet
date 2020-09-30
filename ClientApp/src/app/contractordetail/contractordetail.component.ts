import { Component, OnInit } from '@angular/core';
import { monthlyinput } from '../Model/monthlyinputviewmodel';
import { SheetService } from '../services/sheet.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-contractordetail',
  templateUrl: './contractordetail.component.html',
  styleUrls: ['./contractordetail.component.css']
})
export class ContractordetailComponent implements OnInit {
  expenses:monthlyinput[]=new Array;
  incomesandexpenses:monthlyinput[]=new Array;
  totalexpense:any=0;
  totalincome:any=0;
  balance:any=0;
  contractorid:any=0;
  contractorname:any;
  constructor(private route: ActivatedRoute,private sheetservice:SheetService,private datepipe:DatePipe) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.contractorid = params.get('id');
    });
    this.getcontractormonthlyinput();
    this.getcontractordetail();
  }
  getcontractordetail(){
    this.sheetservice.getcontractordetail(this.contractorid).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.contractorname=res.data.name;
      }
      }, 
      error => console.error(error));
  }
  getcontractormonthlyinput(){
    this.incomesandexpenses=[];
    this.expenses=[];
    this.totalexpense=0;
    this.totalincome=0;
    this.balance=0;
    this.sheetservice.getcontractormonthlyinput(this.contractorid).subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.incomesandexpenses=res.data;
        console.log('getmonthlyinput',res);
        this.expenses=this.incomesandexpenses.filter(x=>x.inputtype==1);
        this.expenses.forEach(element => {
          this.totalexpense=this.totalexpense+element.expenseamount;
        });
      }
      }, 
      error => console.error(error));
  }
}
