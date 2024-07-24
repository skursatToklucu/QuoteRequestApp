import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.css']
})
export class OfferListComponent implements OnInit {
  offers: any[] = [];
  userId: string | null = null;

  constructor(private apiService: ApiService, private authService: AuthService) { }

  ngOnInit() {
    this.userId = this.authService.getUserIdFromToken();
    if (this.userId) {
      this.loadOffers(this.userId);
    } else {
      console.error('User not logged in');
    }
  }

  loadOffers(userId: string) {
    this.apiService.getUserOffers(userId).subscribe(data => {
      this.offers = data;
    });
  }
}
