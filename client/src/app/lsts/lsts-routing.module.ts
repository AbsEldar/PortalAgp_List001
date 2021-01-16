import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LstsComponent } from './lsts.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: '', component:LstsComponent},
  {path: ':id', component: LstsComponent, data: {breadcrumb: {alias: 'lstDetails'}}}
  // {path: ':id', component: }
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
export class LstsRoutingModule { }
