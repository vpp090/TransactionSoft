import { Component, Input } from '@angular/core';
import { Merchant } from 'src/app/models/merchant';

@Component({
  selector: 'app-merchant-item',
  templateUrl: './merchant-item.component.html',
  styleUrls: ['./merchant-item.component.scss']
})
export default class MerchantItemComponent {
  @Input() merchant?: Merchant;
}
