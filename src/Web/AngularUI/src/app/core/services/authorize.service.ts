import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {
  private apiUrl = 'https://localhost:5001/api';
  private token: string  | any= localStorage.getItem('token');
  private isAuthenticated = false;


  constructor(private http: HttpClient, private router: Router) {}


  login(email: string, password: string): Observable<{ accessToken: string }> {
    return this.http.post<{ accessToken: string }>(`${this.apiUrl}/Users/login`, {
      email: email,
      password: password,
    });

  }
  checkTokenAndRedirect(): void {
    if (this.token === null) {
      this.router.navigate(['/']); // Redirect to the homepage route
    }
  }
  getAccessToken(): string | null {
    return this.token;
  }
  isAuthenticatedUser(): boolean {
    const token = this.getAccessToken();
    return token !== null && token !== undefined; // Add your specific logic here
  }

  logout(): void {
    localStorage.removeItem(this.token);
    this.isAuthenticated = false;
    window.location.href = '/';
  }
}
