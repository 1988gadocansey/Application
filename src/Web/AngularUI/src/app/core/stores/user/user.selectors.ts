import { createSelector } from '@ngrx/store';

export const selectFeature = (state: any) => state.user;

export const cartSelector = createSelector(
  selectFeature,
  (state) => state.user
);


