import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfitComponent } from './profit/profit.component';
import { UserComponent } from './user/user.component';

import { AppRoutingModule } from './app-routing.module';
import { HomePageComponent } from './home-page/home-page.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';



import {MatSelectModule} from '@angular/material/select';
import { ApiService } from './api.service';
import { ProfitService } from './profit.service';
import { AddModelService } from './addmodel.service';




@NgModule({
  
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NoopAnimationsModule,
    MatSelectModule,
    
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    UserComponent,
    ProfitComponent,
    HomePageComponent,
  ],

  providers: [ApiService, ProfitService, AddModelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
