import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { initFlowbite } from 'flowbite';
import {SidebarService} from "./core/services/sidebar.service";
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',

})
export class AppComponent  {
  title = 'Takoradi Technical University Application Portal';
constructor(protected sidebar : SidebarService) {
}

}
