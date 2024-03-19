import {Component, inject, OnInit} from '@angular/core';
import {Store} from "@ngrx/store";

import {Client, IClient, UserDto} from "../../web-api-client";

@Component({
  selector: 'app-dashboard',
  standalone: false,

  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
   user: UserDto | undefined
  loading: boolean = false;

  constructor(private store: Store, private httpService: Client) {
    console.log("hi dasboard")
  }
  ngOnInit(): void {this.httpService.index().subscribe(result => {this.user = result})}
}
