import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Merchant } from '../models/merchant';
import { ServiceResponse } from '../models/serviceresponse';
import { Transaction } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getMerchants(){
     return this.http.get<ServiceResponse<Merchant[]>>(this.baseUrl + 'merchant');
  }

  getTransactions(){
     return this.http.get<ServiceResponse<Transaction[]>>(this.baseUrl + 'transaction');
  }
}
