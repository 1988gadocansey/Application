


import { createAction, props } from '@ngrx/store';

import {Observable} from "rxjs";
import {DashboardViewModel} from "../../models/dashboard.model";



export const getAllUsers = createAction('[Users] Get All Users');

export const setUsers = createAction(
  '[Users] Set Users',
  props<{ users: Observable<DashboardViewModel> }>() // Define your user type appropriately
);
