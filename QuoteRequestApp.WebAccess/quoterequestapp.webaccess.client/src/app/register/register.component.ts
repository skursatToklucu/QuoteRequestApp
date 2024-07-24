import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user = {
    email: '',
    password: '',
    confirmPassword: ''
  };

  constructor(private apiService: ApiService, private router: Router) { }

  register(event: Event) {
    console.log(event);
    event.preventDefault(); // Formun varsayılan submit davranışını engelle
    if (this.user.password !== this.user.confirmPassword) {
      console.error('Passwords do not match!');
      return;
    }
    this.apiService.register(this.user).subscribe((response: any) => {
      console.log('User registered', response);
      this.router.navigate(['/login']);
    });
  }

}
