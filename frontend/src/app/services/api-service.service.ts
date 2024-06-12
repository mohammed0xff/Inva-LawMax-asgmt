import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {
  private apiUrl = `${environment.apiUrl}`;

  constructor(
    private http: HttpClient
  ) { }

  getLawyers() {
    return this.http.get<any[]>( this.apiUrl + 'lawyers');
  }

  getCases() {
    return this.http.get<any[]>(this.apiUrl + 'cases');
  }

  getHearings() {
    return this.http.get<any[]>(this.apiUrl + 'Hearings');
  }
}
