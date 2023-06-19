import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Merchant } from './models/merchant';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'TransactionSoft';
  merchants: Merchant[] = [];

  constructor(private http: HttpClient) {}
  
  ngOnInit(): void {
    this.http.get<Merchant[]>('https://localhost:5001/api/merchant').subscribe({
        next: (response: any) => this.merchants = response.data, 
        error: error => console.log(error),
        complete: () => {
           console.log('request completed');
        }
    })
  }
}
