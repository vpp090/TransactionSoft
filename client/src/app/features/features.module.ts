import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MerchantComponent } from './merchant/merchant.component';

import MerchantItemComponent from './merchant-item/merchant-item.component';
import { TransactionItemComponent } from './transaction-item/transaction-item.component';
import { TransactionComponent } from './transaction/transaction.component';



@NgModule({
  declarations: [
    MerchantComponent,
    TransactionComponent,
    MerchantItemComponent,
    TransactionItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
     MerchantComponent,
     TransactionComponent
  ]
})
export class FeaturesModule { }
