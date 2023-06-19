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
 
  constructor() {}
  
  ngOnInit(): void {
   
  }
}
