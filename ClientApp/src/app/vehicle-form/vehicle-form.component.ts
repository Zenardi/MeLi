import { VehicleService } from '../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makers;
  models: any[];
  vehicle: any = {};
  features;

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakers().subscribe(makers => this.makers = makers);
    this.vehicleService.getFeatures().subscribe((features: any) => this.features = features);
  }

  onMakerChange(id) {
    const selectedMaker = (this.models = this.makers.filter(con => {
      // tslint:disable-next-line:triple-equals
      return con.id == this.vehicle.maker;
      })[0]);

    this.models = selectedMaker ? selectedMaker.models : [];

  }

}
