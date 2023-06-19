import { Component, OnInit } from '@angular/core';
import { Transaction } from 'src/app/models/transaction';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.scss']
})
export class TransactionComponent implements OnInit{
    transactions: Transaction[] = [];

    constructor(private apiService: ApiService){}

  ngOnInit(): void {
    this.apiService.getTransactions().subscribe({
        next: response => this.transactions = response.data,
        error: error => console.log(error)
    })
  }
}
