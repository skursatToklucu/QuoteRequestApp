import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Offer } from '../offer/offer.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:5074/api';

  constructor(private http: HttpClient) { }


  login(credentials: { email: string; password: string }): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(`${this.apiUrl}/User/login`, credentials, { headers });
  }

  register(user: { email: string; password: string, confirmPassword: string }): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(`${this.apiUrl}/User/register`, user, { headers });
  }

  getCountries(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/countries`);
  }

  getCities(country: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/cities/${country}`);
  }

  getModes(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/modes`);
  }

  getMovementTypes(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/movementTypes`);
  }

  getIncoterms(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/incoterms`);
  }

  getPackageTypes(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/packageTypes`);
  }

  getUnits(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/units`);
  }

  getCurrencies(): Observable<any> {
    return this.http.get(`${this.apiUrl}/enum/currencies`);
  }

  getDimensions(): Observable<any> {
    return this.http.get(`${this.apiUrl}/dimensions`);
  }

  createOffer(offer: Offer): Observable<Offer> {
    return this.http.post<Offer>(`${this.apiUrl}/offer/createOffer`, offer);
  }

  getUserOffers(userId: string): Observable<Offer[]> {
    return this.http.get<Offer[]>(`${this.apiUrl}/offer/offers/${userId}`);
  }


  calculatePalletCount(unitLength: number, unitType: string): Observable<number> {
    const body = { UnitLength: unitLength, UnitType: unitType };
    return this.http.post<number>(`${this.apiUrl}/dimension/calculatePalletCount`, body);
  }

}

