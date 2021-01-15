import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { UserDetailsComponent } from './user-details/user-details.component';


const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: UserDetailsComponent, data: {breadcrumb: {alias: 'userDetails'}}}
]
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
