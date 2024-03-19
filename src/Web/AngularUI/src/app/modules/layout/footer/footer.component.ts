import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: false,

  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent implements OnInit{
  protected  copyright : string | any
constructor() {
}

  ngOnInit(): void {
    this.copyright = new Date().getFullYear()
  }
}
