import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MonthlyinputComponent } from './monthlyinput/monthlyinput.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';
import { ProjectsComponent } from './projects/projects.component';
import { ContractorsComponent } from './contractors/contractors.component';
import { ContractordetailComponent } from './contractordetail/contractordetail.component';
import { UseroneComponent } from './userone/userone.component';
import { UsertwoComponent } from './usertwo/usertwo.component';
import { TotalprofitsComponent } from './totalprofits/totalprofits.component';
import { CustomexpensesComponent } from './customexpenses/customexpenses.component';
import { TaskcostsComponent } from './taskcosts/taskcosts.component';
import { TaskcostdetailComponent } from './taskcostdetail/taskcostdetail.component';

const routes: Routes = [
  {path:"" , component:HomeComponent},
  {path:"monthlyinput" , component:MonthlyinputComponent},
  {path:"projects" , component:ProjectsComponent},
  {path:"project/:id" , component:ProjectdetailComponent},
  {path:"contractors" , component:ContractorsComponent},
  {path:"contractor/:id" , component:ContractordetailComponent},
  {path:"userone" , component:UseroneComponent},
  {path:"usertwo" , component:UsertwoComponent},
  {path:"totalprofits" , component:TotalprofitsComponent},
  {path:"customexpenses" , component:CustomexpensesComponent},
  {path:"taskcosts" , component:TaskcostsComponent},
  {path:"taskcost/:id" , component:TaskcostdetailComponent},
  {path:"**" , component:HomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
