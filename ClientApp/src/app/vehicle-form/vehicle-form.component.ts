import { VehicleService } from '../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  public get MakerService(): VehicleService {
    return this.vehicleService;
  }
  public set MakerService(value: VehicleService) {
    this.vehicleService = value;
  }
  makers;
  models: any[];
  vehicle: any = {};
  features;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.MakerService.getMakers().subscribe(makers => this.makers = makers);
    this.vehicle.getFeatures().subscribe(features => this.features = features);
  }

  onMakerChange(id) {
    const selectedMaker = (this.models = this.makers.filter(con => {
      // tslint:disable-next-line:triple-equals
      return con.id == this.vehicle.maker;
      })[0]);

    this.models = selectedMaker ? selectedMaker.models : [];

  }

}
