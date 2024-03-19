import { createReducer, on } from '@ngrx/store';
import * as UserActions from './user.actions';
import {DashboardViewModel} from "../../models/dashboard.model";


export const initialState: any = {
  user: null,
  error: null,
};

export const userReducer = createReducer(
  initialState,
  on(UserActions.setUsers, (state) => ({
    ...state,
  }))

);
