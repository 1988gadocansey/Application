// users.effects.ts
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { catchError, map, mergeMap, switchMap } from 'rxjs/operators';
import { HttpService } from '../../services/HttpService'; // Update with the correct path
import * as UsersActions from '../user/user.actions';
import {Observable, of} from 'rxjs';
import {IUserViewModel} from "../../models/dashboard.model";

@Injectable({providedIn:"root"})
export class UsersEffects {

  loadUsers$ = createEffect(() =>
    this.actions$.pipe(
      ofType(UsersActions.setUsers),
      switchMap(() =>
        this.httpService.getUserInfo().pipe(
          map(users => UsersActions.setUsers({users:  this.httpService.getUserInfo() })),
          catchError(error => of(/* handle error if needed */))
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private store: Store,
    private httpService: HttpService
  ) {console.log("use effect called")}
}
