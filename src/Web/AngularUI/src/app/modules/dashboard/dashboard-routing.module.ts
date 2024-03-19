import {inject, NgModule} from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {DashboardModule} from "./dashboard.module";
import {DashboardComponent} from "./dashboard.component";
import {AuthGuard} from "../../core/guards/auth.guard";

const routes: Routes = [

  {
    path: '', component: DashboardComponent,  canActivate: [() => inject(AuthGuard).canActivate()]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
