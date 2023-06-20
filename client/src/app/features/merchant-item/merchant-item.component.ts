import { Component, Input } from '@angular/core';
import { Merchant } from 'src/app/models/merchant';
import { ApiService } from 'src/app/shared/api.service';

@Component({
  selector: 'app-merchant-item',
  templateUrl: './merchant-item.component.html',
  styleUrls: ['./merchant-item.component.scss']
})
export default class MerchantItemComponent {
  @Input() merchant?: Merchant;

 constructor(private apiService: ApiService){}

  deleteMerchant(){
     this.merchant && this.apiService.deleteMerchant(this.merchant.id).subscribe({
        next: response => console.log(response.data),
        error: error => console.log(error)
     });
  }
}
