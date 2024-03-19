import {ChangeDetectorRef, Component, ElementRef, inject} from '@angular/core';
import {AuthorizeService} from "../../../core/services/authorize.service";
import {SidebarService} from "../../../core/services/sidebar.service";


@Component({
  selector: 'app-header',
  standalone: false,

  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
   authService=inject(AuthorizeService)
  sidebarService=inject(SidebarService)
  themeToggleDarkIcon: any
  themeToggleLightIcon:any
  constructor( private el: ElementRef,
               private changeDetector: ChangeDetectorRef) {
    if (localStorage.getItem('color-theme') === 'dark' || (!('color-theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark')
    }
  }

  toggleTheme(): void {
    let event = new Event('dark-mode');

      // if set via local storage previously
      if (localStorage.getItem('color-theme')) {
        if (localStorage.getItem('color-theme') === 'light') {
          document.documentElement.classList.add('dark');
          localStorage.setItem('color-theme', 'dark');
        } else {
          document.documentElement.classList.remove('dark');
          localStorage.setItem('color-theme', 'light');
        }

        // if NOT set via local storage previously
      } else {
        if (document.documentElement.classList.contains('dark')) {
          document.documentElement.classList.remove('dark');
          localStorage.setItem('color-theme', 'light');
        } else {
          document.documentElement.classList.add('dark');
          localStorage.setItem('color-theme', 'dark');
        }
      }

      document.dispatchEvent(event);

  }
toggle(){

    const themeToggleDarkIcon = this.el.nativeElement.querySelector('.theme-toggle-dark-icon');
    const themeToggleLightIcon = this.el.nativeElement.querySelector('.theme-toggle-light-icon');

    // Change the icons inside the button based on previous settings
    if (localStorage.getItem('color-theme') === 'dark' || (!localStorage.getItem('color-theme') && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
      themeToggleDarkIcon.classList.remove('hidden');
      themeToggleLightIcon.classList.add('hidden');
    } else {
      themeToggleLightIcon.classList.remove('hidden');
      themeToggleDarkIcon.classList.add('hidden');
    }

    const themeToggleBtn = this.el.nativeElement.querySelector('.theme-toggle');

    themeToggleBtn.addEventListener('click', () => {
      // toggle icons
      themeToggleDarkIcon.classList.toggle('hidden');
      themeToggleLightIcon.classList.toggle('hidden');

      // Toggle dark mode class on <html> element
      document.documentElement.classList.toggle('dark');

      // Update color theme in localStorage
      const isDarkMode = document.documentElement.classList.contains('dark');
      localStorage.setItem('color-theme', isDarkMode ? 'dark' : 'light');

      // Dispatch event
      const event = new Event('dark-mode');
      document.dispatchEvent(event);
    });


}
  toggleMobileMenu(): void{
    alert("mobile toggle")
  }
  logout(){
     this.authService.logout();
  }
}
