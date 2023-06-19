import { Component, OnInit } from '@angular/core';
import { Merchant } from 'src/app/models/merchant';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-merchant',
  templateUrl: './merchant.component.html',
  styleUrls: ['./merchant.component.scss']
})
export class MerchantComponent implements OnInit {
  merchants: Merchant[] = [];
  
constructor(private apiService: ApiService){}

  ngOnInit(): void {
     this.apiService.getMerchants().subscribe({
          next: response => this.merchants = response.data,
          error: error => console.log(error)
     });
  }

}
