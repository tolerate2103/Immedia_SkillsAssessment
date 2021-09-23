import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';


@Injectable()
export class DataService {

  apiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiUrl = "http://localhost:30396/";
  }

  //Used for API calls
  get(action: string, params: HttpParams) {
    let options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }), params: params
    };
    return this.http.get(this.apiUrl + action, options)
  }

  post(action: string, parameters: object) {
    let options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    console.log(this.apiUrl);
    return this.http.post(this.apiUrl + action, JSON.stringify(parameters), options);
  }

}
