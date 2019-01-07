import { MakerService } from './../services/maker.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  public get MakerService(): MakerService {
    return this._MakerService;
  }
  public set MakerService(value: MakerService) {
    this._MakerService = value;
  }
  makers;
  models: any[];

  vehicle: any = {};

  constructor(private _MakerService: MakerService) { }

  ngOnInit() {
    this.MakerService.getMakers().subscribe(makers => this.makers = makers);
  }

  onMakerChange(id) {
    // this.models = this.makers.find(con => {
    //   return con.id === this.vehicle.maker;
    // }).models;
    // tslint:disable-next-line:triple-equals
    console.log(this.vehicle.maker);
    console.log(this.models = this.makers.filter(con => {
         // tslint:disable-next-line:triple-equals
         return con.id == this.vehicle.maker;
        }));

        this.models = (this.models = this.makers.filter(con => {
    // tslint:disable-next-line:triple-equals
    return con.id == this.vehicle.maker;
    })[0].models);
    // tslint:disable-next-line:triple-equals
    // this.models = this.makers.filter((item) => item.id == id).models;

  }

}
