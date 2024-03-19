import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PassportComponent} from "./passport.component";
import {PassportRoutingModule} from "./passport.routing.module";



@NgModule({
  declarations: [ PassportComponent],
  imports: [
    CommonModule,
    PassportRoutingModule
  ]
})
export class PassportModule { }
