// src/app/seguro.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment'; // Ajusta la ruta según tu estructura

@Injectable({
  providedIn: 'root'
})
export class SeguroService {
  private apiUrl = `${environment.apiUrl}/seguros`;

  constructor(private http: HttpClient) { }

  getAllSeguros(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getSeguro(codigo: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${codigo}`);
  }

  addSeguro(seguro: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, seguro);
  }

  updateSeguro(seguro: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${seguro.codigo}`, seguro);
  }

  deleteSeguro(codigo: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${codigo}`);
  }
}
