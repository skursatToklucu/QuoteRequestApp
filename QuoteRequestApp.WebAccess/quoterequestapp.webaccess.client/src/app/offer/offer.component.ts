import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { AuthService } from '../services/auth.service';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {
  offer = {
    mode: '',
    movementType: '',
    incoterms: '',
    country: '',
    city: '',
    packageType: '',
    unit1: '',
    unit2: '',
    currency: ''
  };

  unit1Value: number = 0;
  unit1Type: string = '';
  unit2Value: number = 0;
  unit2Type: string = '';

  modes: string[] = [];
  movementTypes: string[] = [];
  incoterms: string[] = [];
  countries: string[] = [];
  cities: string[] = [];
  packageTypes: string[] = [];
  units: string[] = [];
  currencies: string[] = [];
  dimensions: any[] = [];
  boxCount: number = 0;
  palletCount: number = 0;
  userId: string | null = null;

  constructor(
    private apiService: ApiService,
    private authService: AuthService,
    private message: NzMessageService
  ) { }

  ngOnInit() {
    this.loadEnums();
    this.loadDimensions();
    this.userId = this.authService.getUserIdFromToken();
  }

  loadEnums() {
    this.apiService.getModes().subscribe(data => this.modes = data);
    this.apiService.getMovementTypes().subscribe(data => this.movementTypes = data);
    this.apiService.getIncoterms().subscribe(data => this.incoterms = data);
    this.apiService.getCountries().subscribe(data => this.countries = data);
    this.apiService.getPackageTypes().subscribe(data => this.packageTypes = data);
    this.apiService.getCurrencies().subscribe(data => this.currencies = data);
  }

  loadDimensions() {
    this.apiService.getDimensions().subscribe(data => this.dimensions = data);
  }

  onCountryChange() {
    this.offer.city = '';
    this.cities = [];
    if (this.offer.country) {
      this.apiService.getCities(this.offer.country).subscribe(data => this.cities = data);
    }
  }

  calculatePalletCount(): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      const unitLength = this.unit1Value;
      const unitType = this.unit1Type;


      if (unitLength < 1 || unitLength > 1000) {
        this.message.error('Unit 1 must be between 1 and 1000 cm.');
        reject(new Error('Invalid Unit 1 value'));
        return;
      }

      if (this.unit2Value < 0.1 || this.unit2Value > 1000) {
        this.message.error('Unit 2 must be between 0.1 and 1000 kg.');
        reject(new Error('Invalid Unit 2 value'));
        return;
      }

      this.apiService.calculatePalletCount(unitLength, unitType).subscribe(
        data => {
          this.palletCount = data;
          this.message.success(`Pallet count calculated: ${this.palletCount}`);
          resolve();
        },
        error => {
          this.message.error(error.error.message);
          console.error('Error:', error);
          reject(error);
        }
      );
    });
  }

  validateMode(): boolean {
    if (this.offer.mode === 'LCL' && this.palletCount >= 24) {
      this.message.warning("For pallet counts of 24 or more, please choose FCL mode.");
      return false; // İlerlemeyi durdur
    } else if (this.offer.mode === 'FCL' && this.palletCount > 24) {
      this.message.error("FCL mode cannot ship more than 24 pallets.");
      return false; // İlerlemeyi durdur
    }
    return true; // İlerlemeye devam et
  }

  async submitOffer() {
    if (this.userId) {
      try {
        await this.calculatePalletCount(); // Palet sayısını hesapla ve bitene kadar bekle

        if (!this.validateMode()) {
          return; // Eğer mod geçerli değilse, işlemi durdur
        }

        const unit1 = `${this.unit1Value}${this.unit1Type}`;
        const unit2 = `${this.unit2Value}${this.unit2Type}`;

        const offerWithUserId = {
          ...this.offer,
          unit1: unit1,
          unit2: unit2,
          userId: this.userId
        };

        console.log('Offer submitted', offerWithUserId);
        this.apiService.createOffer(offerWithUserId).subscribe(
          response => {
            console.log('Offer successfully submitted', response);
            this.message.success('Offer successfully submitted.');
          },
          error => {
            console.error('Error submitting offer', error);
            this.message.error('Error submitting offer.');
          }
        );
      } catch (error) {
        console.error('Error in offer submission process', error);
      }
    } else {
      this.message.error('User not logged in');
    }
  }
}
