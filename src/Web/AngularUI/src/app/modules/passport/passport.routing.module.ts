import {RouterModule, Routes} from "@angular/router";
import {inject, NgModule} from "@angular/core";
import {PassportComponent} from "./passport.component";
import {AuthGuard} from "../../core/guards/auth.guard";
import {DashboardComponent} from "../dashboard/dashboard.component";

const routes: Routes = [

  {
    path: '', component: PassportComponent,  canActivate: [() => inject(AuthGuard).canActivate()]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PassportRoutingModule { }
