import { Component } from '@angular/core';
import {LoadingService} from "../../core/services/loading.service";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-spinner',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.css'
})
export class SpinnerComponent {
  constructor(public loader: LoadingService) { }
}
