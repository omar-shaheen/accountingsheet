import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MonthlyinputComponent } from './monthlyinput/monthlyinput.component';
import { SheetService } from './services/sheet.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectdetailComponent } from './projectdetail/projectdetail.component';
import { ContractorsComponent } from './contractors/contractors.component';
import { ContractordetailComponent } from './contractordetail/contractordetail.component';
import { TotalprofitsComponent } from './totalprofits/totalprofits.component';
import { UseroneComponent } from './userone/userone.component';
import { UsertwoComponent } from './usertwo/usertwo.component';
import { CustomexpensesComponent } from './customexpenses/customexpenses.component';
import { TaskcostsComponent } from './taskcosts/taskcosts.component';
import { TaskcostdetailComponent } from './taskcostdetail/taskcostdetail.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MonthlyinputComponent,
    ProjectsComponent,
    ProjectdetailComponent,
    ContractorsComponent,
    ContractordetailComponent,
    TotalprofitsComponent,
    UseroneComponent,
    UsertwoComponent,
    CustomexpensesComponent,
    TaskcostsComponent,
    TaskcostdetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [SheetService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
