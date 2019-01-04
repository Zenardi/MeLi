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
  makers: any;
  models: any[];

  vehicle: any = {};

  constructor(private _MakerService: MakerService) { }

  ngOnInit() {
    this.MakerService.getMakers().subscribe(makers => this.makers = makers);
  }

  onMakerChange() {
    this.models = this.makers.find(con => {
      return con.id === this.vehicle.maker;
    }).models;

  }

}
