import {ApplicationConfig} from '@angular/core';
import {provideRouter} from '@angular/router';

import {routes} from './app.routes';
import {provideStore} from '@ngrx/store';

import {HTTP_INTERCEPTORS, provideHttpClient, withInterceptors} from "@angular/common/http";

import {tokenHttpInterceptor} from "./core/interceptors/tokenHttpInterceptor";
import {provideAnimations} from "@angular/platform-browser/animations";
import {provideToastr} from "ngx-toastr";
import {userReducer} from "./core/stores/user/user.reducer";
import {ThemeService} from "./core/services/theme.service";
import {provideClientHydration} from "@angular/platform-browser";


export const appConfig: ApplicationConfig = {
  providers: [

    provideAnimations(),
    provideClientHydration(), provideRouter(routes),
    ThemeService,
    provideHttpClient(withInterceptors([tokenHttpInterceptor])),
    provideAnimations(), // required animations providers
    provideToastr({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),

    provideStore({user: userReducer}),

  ],

};
