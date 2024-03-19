import {inject, NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from "./layout.component";
import {AuthGuard} from "../../core/guards/auth.guard";


const routes: Routes = [
  {
    path: 'dashboard',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    loadChildren: () => import('../dashboard/dashboard.module').then((m) => m.DashboardModule),

  },
  {
    path: 'picture/upload',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    loadChildren: () => import('../passport/passport.module').then((m) => m.PassportModule),

  },
  ]
RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class LayoutRoutingModule { }
