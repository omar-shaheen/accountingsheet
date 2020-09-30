import { Component, OnInit } from '@angular/core';
import { contractor } from '../Model/contractor';
import { SheetService } from '../services/sheet.service';
import { mastercontractor } from '../Model/mastercontractor';

@Component({
  selector: 'app-contractors',
  templateUrl: './contractors.component.html',
  styleUrls: ['./contractors.component.css']
})
export class ContractorsComponent implements OnInit {
  contractors:contractor[]=new Array;
  deletedcontractors:contractor[]=new Array;
  updatedcontractors:contractor[]=new Array;
  disabled:boolean=false;
  constructor(private sheetservice:SheetService) { }

  ngOnInit(): void {
    this.getcontractors();
  }

  getcontractors(){
    this.sheetservice.getListcontractors().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.contractors=res.data;
      }
      }, 
      error => console.error(error));
  }

  contractorname:any;
  contractorcurrentindex:any=-1;
  contractorcurrentitemid:any=0;
  total:any=0;
  addcontractor(id,projectname){
    var _contractor=new contractor();
    _contractor.id=id;
    _contractor.total=0;
    _contractor.name=projectname;
    _contractor.flagechange=true;
    if(this.contractorcurrentindex>-1){ 
    // this.contractors[this.contractorcurrentindex]=_contractor;
    this.addorupdatecontractor(_contractor);
    }else{
    // this.contractors.push(_contractor);
    this.addorupdatecontractor(_contractor);
    }
    

    this.resetprojectform();
    
 }
 resetprojectform(){
  this.contractorcurrentindex=-1;
  this.contractorcurrentitemid=0;
   this.contractorname=undefined;
 }

 
 rowElim(item:contractor){
   if(item!=null){     
    //  const index: number = this.contractors.indexOf(item);
    //  if (index !== -1) {
    //     this.contractors.splice(index, 1);
    //     if(item.id>0){
    //       this.deletedcontractors.push(item);
    //     }
    //   }        
    this.sheetservice.deletecontractor(item.id).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getcontractors();
      this.disabled=false;
      }, 
      error => console.error(error));     
   }
 }


 rowEdit(item:contractor){
   if(item!=null){
     this.contractorcurrentitemid = item.id;
     this.total=item.total;
     this.contractorname=item.name;
     this.contractorcurrentindex = this.contractors.indexOf(item);
   }
   
 }






 suubmitcontractorschanges(){
  this.disabled=true;
    var _model=new   mastercontractor();
    _model.deletedcontractors=this.deletedcontractors;
    this.contractors.forEach(element => {
      if(element.flagechange){
        this.updatedcontractors.push(element);
      }
    });
    _model.contractors=this.updatedcontractors;
    console.log(_model);
     this.sheetservice.suubmitcontractorss(_model).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getcontractors();
      this.disabled=false;
      }, 
      error => console.error(error));
  }


  addorupdatecontractor(_contractor:contractor){
    console.log('_contractor',_contractor);
   this.sheetservice.addcontractor(_contractor).subscribe(res => {    
     if(res!=null && res.code=="999"){
       console.log('dataupdatedsuccessfully');
     }else{
       console.log('error found');
     }
     this.getcontractors();
     this.disabled=false;
     }, 
     error => console.error(error));
  }



}