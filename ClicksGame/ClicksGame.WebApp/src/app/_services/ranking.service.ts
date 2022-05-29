import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RankingService{

  private BASE_URL = environment.baseUrl;

  constructor(
    private http: HttpClient ) {
  
  }

  getRanking() {
    return this.http.get(`${this.BASE_URL}ranking`);
  }

}
