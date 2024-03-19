import {Component, OnInit} from '@angular/core';
import {RouterLink, RouterOutlet} from "@angular/router";
import {NgFor} from "@angular/common";
import {
  DarkThemeToggleComponent, DropdownComponent, DropdownHeaderComponent, DropdownItemComponent,
  NavbarComponent,
  SidebarComponent,
  SidebarItemComponent,
  SidebarItemGroupComponent
} from "../../../libs/flowbite-angular/src";
import { components } from './../../common/components';
import {SidebarService} from "../../core/services/sidebar.service";
import {initFlowbite} from "flowbite";
@Component({

  standalone: true,
  imports: [
    NavbarComponent,
    SidebarComponent,
    SidebarItemComponent,
    SidebarItemGroupComponent,
    RouterOutlet,
    DarkThemeToggleComponent,
    NgFor,

  ],

  templateUrl: './sitelayout.component.html',
  styleUrl: './sitelayout.component.css'
})
export class SitelayoutComponent implements  OnInit{

  components = components;

  constructor(protected readonly sidebarService: SidebarService) {}
  ngOnInit(): void {
    initFlowbite();
  }
}
