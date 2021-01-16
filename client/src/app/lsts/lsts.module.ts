import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LstsComponent } from './lsts.component';
import { LstsRoutingModule } from './lsts-routing.module';



@NgModule({
  declarations: [LstsComponent],
  imports: [
    CommonModule,
    LstsRoutingModule
  ],
  exports: [
    LstsComponent
  ]
})
export class LstsModule { }
