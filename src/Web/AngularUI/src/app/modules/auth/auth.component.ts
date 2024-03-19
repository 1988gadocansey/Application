import {Component, inject, OnInit} from '@angular/core';
import {Router, RouterOutlet} from '@angular/router';
import { AngularSvgIconModule } from 'angular-svg-icon';
import {FormBuilder} from "@angular/forms";
import {HttpService} from "../../core/services/HttpService";

@Component({
    selector: 'app-auth',
    templateUrl: './auth.component.html',
    styleUrls: ['./auth.component.scss'],
    standalone: true,
    imports: [AngularSvgIconModule, RouterOutlet  ],
})

export class AuthComponent implements OnInit {

  constructor() {}

  ngOnInit(): void {}
}
