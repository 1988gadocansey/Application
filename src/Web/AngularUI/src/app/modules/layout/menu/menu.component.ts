
import { Component, Input } from '@angular/core';
import {SidebarService} from "../../../core/services/sidebar.service";

@Component({
  selector: 'app-menu',
  standalone: false,

  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  @Input() extraClass = '';
  @Input() rounded = false;
  constructor(readonly sidebarService: SidebarService) {}
}
