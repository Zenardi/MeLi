import { Injectable } from '@angular/core';
// import { HttpModule } from '@angular/http';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MakerService {

  constructor(private http: HttpClient) { }

  getMakers() {
    return this.http.get('/api/makers');
  }
}
