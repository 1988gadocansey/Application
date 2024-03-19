import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SidebarToggleService {
  private sidebarOpenSubject = new Subject<boolean>();
  sidebarOpen$ = this.sidebarOpenSubject.asObservable();

  constructor() { }

  toggleSidebar(open: boolean) {
    this.sidebarOpenSubject.next(open);
  }
}
