import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

import { Month } from '../api'

export interface Monthes {
  Id: number;
  viewValue: String;
}



@Component({
  selector: 'app-heroes',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {
  month: Month[];
  monthSelected: Number;
  public list = {}
  months: Monthes[];
  constructor( private api: ApiService) {
    
   }

  check(month: number): void{
    console.log("value check", month)
    this.api.getAllCars({month} as Month).subscribe(res => {
      console.log(res)
      // this.list = month
    })
  }


  ngOnInit() {
    this.months =[
      { Id: 1, viewValue: "January" },
      { Id: 2, viewValue: "February" },
      { Id: 3, viewValue: "March" },
      { Id: 4, viewValue: "April" },
      { Id: 5, viewValue: "May" },
      { Id: 6, viewValue: "June" },
      { Id: 7, viewValue: 'July' },
      { Id: 8, viewValue: 'August' },
      { Id: 9, viewValue: 'Suptember' },
      { Id: 10, viewValue: 'October' },
      { Id: 11, viewValue: 'November' },
      { Id: 12, viewValue: 'December' },
  
    ];
    this.monthSelected = 1;
  }

}