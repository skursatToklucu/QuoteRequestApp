import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  credentials = {
    email: '',
    password: ''
  };

  constructor(private apiService: ApiService, private authService: AuthService, private router: Router) { }

  login() {
    this.apiService.login(this.credentials).subscribe(
      (response: any) => {
        console.log('User logged in', response);
        this.authService.login(response.token); 
        this.router.navigate(['/offer']);
      },
      (error: any) => {
        console.error('Login error', error); 
      }
    );
  }

  goToRegister() {
    this.router.navigate(['/register']);
  }
}
