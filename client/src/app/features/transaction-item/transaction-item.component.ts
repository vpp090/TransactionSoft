import { Component, Input } from '@angular/core';
import { Transaction } from 'src/app/models/transaction';
import { ApiService } from 'src/app/shared/api.service';

@Component({
  selector: 'app-transaction-item',
  templateUrl: './transaction-item.component.html',
  styleUrls: ['./transaction-item.component.scss']
})
export class TransactionItemComponent {
  @Input() transaction?: Transaction

  constructor(private apiService: ApiService){}

  processTransaction(){
   
    this.transaction && this.apiService.processTransaction(this.transaction.id).subscribe({
        next: response => console.log(response.data),
        error: error => console.log(error)
    });
    
  }
}
