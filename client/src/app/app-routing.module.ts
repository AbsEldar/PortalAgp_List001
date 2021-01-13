import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopComponent } from './shop/shop.component';
import { UserDetailsComponent } from './shop/user-details/user-details.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'shop', component: ShopComponent},
  {path: 'shop/:id', component: UserDetailsComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
