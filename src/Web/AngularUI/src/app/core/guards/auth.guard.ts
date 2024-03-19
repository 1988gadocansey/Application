import { Injectable } from '@angular/core';

import { AuthorizeService } from '../services/authorize.service';
import {CanActivateFn, Router} from "@angular/router";




@Injectable({
  providedIn: 'root'
})
export class AuthGuard   {
  constructor(private authService: AuthorizeService, private router: Router) {}

  canActivate(): boolean {
    return this.checkAuth();
  }

  canActivateChild(): boolean {
    return this.checkAuth();
  }



  canLoad(): boolean {
    return this.checkAuth();
  }

  private checkAuth(): boolean {
    if (this.authService.isAuthenticatedUser()) {
      return true;
    } else {
      // Redirect to the login page if the user is not authenticated
      this.router.navigate(['/']);
      return false;
    }
  }



}
