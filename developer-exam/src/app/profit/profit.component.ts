import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ProfitService } from '../profit.service';

import { Profit } from '../profit'



export interface Monthes {
  Id: number;
  viewValue: string;
}
@Component({
  selector: 'app-hero-detail',
  templateUrl: './profit.component.html',
  styleUrls: ['./profit.component.css']
})

export class  ProfitComponent implements OnInit {
  months: Monthes[];
  monthSelected: Number;

  constructor( 
    private route: ActivatedRoute,
    private location: Location,
    private api: ProfitService) { }

    profit(month: number): void{
      console.log("value check", month)
      this.api.getAllProfit({month} as Profit).subscribe(res => {
        console.log(res, "profit")
        // this.list = month
      })
    }

  ngOnInit(): void {
    this.months = [
      { Id: 1, viewValue: 'January' },
      { Id: 2, viewValue: 'February' },
      { Id: 3, viewValue: 'March' },
      { Id: 4, viewValue: 'April' },
      { Id: 5, viewValue: 'May' },
      { Id: 6, viewValue: 'June' },
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
