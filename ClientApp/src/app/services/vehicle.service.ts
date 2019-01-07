import { Injectable } from '@angular/core';
// import { HttpModule } from '@angular/http';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }

  getMakers() {
    return this.http.get('/api/makers');
  }

  getFeatures() {
    return this.http.get('/api/features');
  }
}
