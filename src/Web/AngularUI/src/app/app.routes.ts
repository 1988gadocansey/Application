import {Routes} from '@angular/router';
import {DashboardComponent} from "./modules/dashboard/dashboard.component";
import {AuthGuard} from "./core/guards/auth.guard";
import {inject} from "@angular/core";
import {PassportComponent} from "./modules/passport/passport.component";
import {DashboardPageComponent} from "./pages";
import {SitelayoutComponent} from "./shared/sitelayout/sitelayout.component";

export const routes: Routes = [
  {path: '', redirectTo: '/auth', pathMatch: 'full'},

  {
    path: '',
    component: SitelayoutComponent,
    children: [
      {
        path: 'me',
        component: DashboardPageComponent,
      },
      { path: '', redirectTo: 'enterprise', pathMatch: 'full' },
    ],
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: '',
    loadChildren: () => import('./modules/layout/layout.module').then((m) => m.LayoutModule),
  },

  {
    path: 'print',
    loadChildren: () => import('./modules/print/print.module').then((m) => m.PrintModule),
  },
  {path: '**', redirectTo: '/404', pathMatch: 'full'},
];

