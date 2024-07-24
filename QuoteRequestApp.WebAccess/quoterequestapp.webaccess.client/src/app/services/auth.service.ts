import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = false;

  constructor(private http: HttpClient) { }

  login(token: string) {
    localStorage.setItem('token', token); // Token'ı yerel depolamaya kaydedin
  }

  logout() {
    this.loggedIn = false;
    localStorage.removeItem('token'); // Token'ı yerel depolamadan sil
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token'); // Veya başka bir oturum kontrol yöntemi
  }

  getUserIdFromToken(): string | null {
    const token = localStorage.getItem('token');
    if (!token) return null;

    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload.nameid || null;
    } catch (e) {
      console.error('Token parsing error', e);
      return null;
    }
  }
}
