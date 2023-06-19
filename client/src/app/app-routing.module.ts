import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MerchantComponent } from './features/merchant/merchant.component';
import { TransactionComponent } from './features/transaction/transaction.component';

const routes: Routes = [
  {path: 'merchants', component: MerchantComponent},
  {path: 'transactions', component: TransactionComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
