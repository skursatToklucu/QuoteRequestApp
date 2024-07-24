import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from './services/auth.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isCollapsed = false;

  constructor(public authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.checkLoginStatus();
    this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        console.log('Current URL:', event.urlAfterRedirects);

        // Eğer kullanıcı giriş yapmamışsa ve mevcut sayfa login veya register değilse login sayfasına yönlendir
        if (!this.authService.isLoggedIn() && event.urlAfterRedirects !== '/register' && event.urlAfterRedirects !== '/login') {
          //this.router.navigate(['/login']);
        }

        // Eğer kullanıcı giriş yapmışsa ve mevcut sayfa login veya register ise offer sayfasına yönlendir
        if (this.authService.isLoggedIn() && (event.urlAfterRedirects === '/login' || event.urlAfterRedirects === '/register')) {
          this.router.navigate(['/offer']);
        }
      });
  }


  checkLoginStatus() {
    if (this.authService.isLoggedIn()) {
      this.router.navigate(['/offer']);
    } else {
      //this.router.navigate(['/login']);
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
