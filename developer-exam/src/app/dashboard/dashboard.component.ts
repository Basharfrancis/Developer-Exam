import { Component, OnInit } from '@angular/core';
import { AddModelService } from '../addmodel.service';
import { AddModel } from '../addmodel';

export interface Color {
  Id: Number;
  viewValue: String;
}
export interface Type {
  Id: Number;
  viewValue: String;
}


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  colors: Color[];
  colorSelected: Number
  types: Type[];
  typesSelected: Number;


  addmodel:AddModel[];

  constructor(
     private api: AddModelService
     ) { }

     add(model: Object): void{
      console.log("value check", model)
      this.api.addNewCar({model} as AddModel).subscribe(res => {
        console.log(res)
        // this.list = month
      })
    }

  ngOnInit() {
    this.colors =  [
    { Id: 1, viewValue: "Red" },
    { Id: 2, viewValue: "Blue" },
    { Id: 3, viewValue: "Black" },
    { Id: 4, viewValue: "White" },
    { Id: 5, viewValue: "Gray" },
  ]
    this.types =  [
    { Id: 1, viewValue: "Sedan" },
    { Id: 2, viewValue: "SUV" },
    { Id: 3, viewValue: "Sports" },
  ]
  this.colorSelected = 1;
  this.typesSelected = 1;
  }





}
