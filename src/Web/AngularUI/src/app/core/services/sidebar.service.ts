import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SidebarService {
  $collapsed = new BehaviorSubject<boolean>(false);

  setCollapsed(collapsed: boolean) {
   // console.log("set collapse")

    this.$collapsed.next(collapsed);
  }

  toggleCollapsed() {
//console.log("collapsed")
    const collapsed = this.$collapsed.getValue();
    this.setCollapsed(!collapsed);
  }
}
