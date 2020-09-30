import { Component, OnInit } from '@angular/core';
import { monthviewmodel } from '../Model/monthviewmodel';
import { yearviewmodel } from '../Model/yearviewmodel';
import { SheetService } from '../services/sheet.service';

@Component({
  selector: 'app-totalprofits',
  templateUrl: './totalprofits.component.html',
  styleUrls: ['./totalprofits.component.css']
})
export class TotalprofitsComponent implements OnInit {
months:monthviewmodel[]=new Array;
years:yearviewmodel[]=new Array;
year:any;
  constructor(private sheetservice:SheetService) { }

  ngOnInit(): void {
    this.year=new Date().getFullYear();
    this.getmonthsprofits();
    this.getyears();
  }
getyears(){
  this.sheetservice.getyears().subscribe(res => {    
    if(res!=null && res.code=="999"){
      this.years=res.data;
    }
    }, 
    error => console.error(error));
}



getmonthsprofits(){
  this.months=[];
  this.sheetservice.getmonthsprofits(this.year).subscribe(res => {    
    if(res!=null && res.code=="999"){
      this.months=res.data;
    }
    }, 
    error => console.error(error));
}


}
