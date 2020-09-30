import { Component, OnInit } from '@angular/core';
import { SheetService } from '../services/sheet.service';
import { project } from '../Model/project';
import { masterproject } from '../Model/masterproject';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  projects:project[]=new Array;
  deletedprojects:project[]=new Array;
  updatedprojects:project[]=new Array;
  disabled:boolean=false;
  constructor(private sheetservice:SheetService) { }

  ngOnInit(): void {
    this.getprojects();
  }

  getprojects(){
    this.sheetservice.fetchprojects().subscribe(res => {    
      if(res!=null && res.code=="999"){
        this.projects=res.data;
      }
      }, 
      error => console.error(error));
  }
  projectordernumber:any;
  projectname:any;
  projectcurrentindex:any=-1;
  projectcurrentitemid:any=0;
  income:any=0;
  expense:any=0;
  addproject(id,projectname,projectordernumber:any){
    var _project=new project();
    _project.id=id;
    _project.income=0;
    _project.expense=0;
    _project.name=projectname;
    _project.flagchange=true;
    _project.type=4;
    _project.ordernumber=parseInt(projectordernumber) ;
    if(this.projectcurrentindex>-1){ 
     //this.projects[this.projectcurrentindex]=_project;
     this.addprojects(_project);
    }else{
     //this.projects.push(_project);
     this.addprojects(_project);
    }
    this.resetprojectform();   
 }
 resetprojectform(){
   this.projectcurrentindex=-1;
   this.projectcurrentitemid=0;
   this.projectname=undefined;
 }

 
 rowElim(item:project){
   if(item!=null){     
    //  const index: number = this.projects.indexOf(item);
    //  if (index !== -1) {
    //     this.projects.splice(index, 1);
    //     if(item.id>0){
    //       this.deletedprojects.push(item);
    //     }
    //   }   
    this.sheetservice.deleteproject(item.id).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getprojects();
      this.disabled=false;
      }, 
      error => console.error(error));     
    }
 }


 rowEdit(item:project){
   if(item!=null){
     this.projectcurrentitemid = item.id;
     this.income=item.income;
     this.expense=item.expense;
     this.projectname=item.name;
     this.projectordernumber=item.ordernumber;
     this.projectcurrentindex = this.projects.indexOf(item);
   }
   
 }






 saveprojectschanges(){
  this.disabled=true;
    var _model=new   masterproject();
    _model.deletedprojects=this.deletedprojects;
    this.projects.forEach(element => {
      if(element.flagchange){
        this.updatedprojects.push(element);
      }
    });
    _model.projects=this.updatedprojects;
    console.log(_model);
     this.sheetservice.suubmitprojects(_model).subscribe(res => {    
      if(res!=null && res.code=="999"){
        console.log('dataupdatedsuccessfully');
      }else{
        console.log('error found');
      }
      this.getprojects();
      this.disabled=false;
      }, 
      error => console.error(error));
  }


  addprojects(_project:project){
    console.log('project',_project);
   this.sheetservice.addproject(_project).subscribe(res => {    
     if(res!=null && res.code=="999"){
       console.log('dataupdatedsuccessfully');
     }else{
       console.log('error found');
     }
     this.getprojects();
     this.disabled=false;
     }, 
     error => console.error(error));
  }

}
