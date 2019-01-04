import { MakerService } from './../services/maker.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makers;
  // tslint:disable-next-line:no-shadowed-variable
  constructor(private MakerService: MakerService) { }

  ngOnInit() {
    this.MakerService.getMakers().subscribe(makers => {
      this.makers = makers;
      console.log('MAKERS', this.makers);
    });


  }

}
