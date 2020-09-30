import { Component, OnInit } from '@angular/core';
import { taskcost } from '../Model/taskcost';
import { SheetService } from '../services/sheet.service';
import { mastertaskcost } from '../Model/mastertaskcost';

@Component({
  selector: 'app-taskcosts',
  templateUrl: './taskcosts.component.html',
  styleUrls: ['./taskcosts.component.css']
})
export class TaskcostsComponent implements OnInit {
  taskcosts:taskcost[]=new Array;
  deletedtaskcosts:taskcost[]=new Array;
  updatedtaskcosts:taskcost[]=new Array;
  disabled:boolean=false;
  constructor(private sheetservice:SheetService) { }

  ngOnInit(): void {
    this.gettaskcosts();
  }

  gettaskcosts(){
    this.sheetservice.getListtaskcosts().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.taskcosts=res.data;
      }
      }, 
      error => console.error(error));
  }

  contractorname:any;
  contractorcurrentindex:any=-1;
  contractorcurrentitemid:any=0;
  total:any=0;
  addcontractor(id,projectname){
    var _taskcost=new taskcost();
    _taskcost.id=id;
    _taskcost.total=0;
    _taskcost.name=projectname;
    _taskcost.flagchange=true;
    if(this.contractorcurrentindex>-1){ 
     //this.taskcosts[this.contractorcurrentindex]=_contractor;
     this.addtaskcost(_taskcost);
    }else{
     //this.taskcosts.push(_contractor);
     this.addtaskcost(_taskcost);
    }
    

    this.resetprojectform();
    
 }
 resetprojectform(){
  this.contractorcurrentindex=-1;
  this.contractorcurrentitemid=0;
   this.contractorname=undefined;
 }

 
 rowElim(item:taskcost){
   if(item!=null){     
    //  const index: number = this.taskcosts.indexOf(item);
    //  if (index !== -1) {
    //     this.taskcosts.splice(index, 1);
    //     if(item.id>0){
    //       this.deletedtaskcosts.push(item);
    //     }
    //   }  
    this.sheetservice.deletetaskcost(item.id).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.gettaskcosts();
      this.disabled=false;
      }, 
      error => console.error(error));           
    }
 }


 rowEdit(item:taskcost){
   if(item!=null){
     this.contractorcurrentitemid = item.id;
     this.total=item.total;
     this.contractorname=item.name;
     this.contractorcurrentindex = this.taskcosts.indexOf(item);
   }
   
 }






 suubmittaskcostschanges(){
  this.disabled=true;
    var _model=new   mastertaskcost();
    _model.deletedtaskcosts=this.deletedtaskcosts;
    this.taskcosts.forEach(element => {
      if(element.flagchange){
        this.updatedtaskcosts.push(element);
      }
    });
    _model.taskcosts=this.updatedtaskcosts;
    console.log(_model);
     this.sheetservice.suubmittaskcostss(_model).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.gettaskcosts();
      this.disabled=false;
      }, 
      error => console.error(error));
  }


  addtaskcost(_taskcost:taskcost){
    console.log('_taskcost',_taskcost);
   this.sheetservice.addtaskcost(_taskcost).subscribe(res => {    
     if(res!=null && res.code=="999"){
       console.log('dataupdatedsuccessfully');
     }else{
       console.log('error found');
     }
     this.gettaskcosts();
     this.disabled=false;
     }, 
     error => console.error(error));
  }
}