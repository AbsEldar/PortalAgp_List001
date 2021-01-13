import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { UserItemComponent } from './user-item/user-item.component';
import { SharedModule } from '../shared/shared.module';
import { UserDetailsComponent } from './user-details/user-details.component';



@NgModule({
  declarations: [ShopComponent, UserItemComponent, UserDetailsComponent],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
