import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Asegurado, AseguradoNoId } from './modelos/asegurado.model';

@Injectable({
  providedIn: 'root'
})
export class AseguradoService {
  private apiUrl = `${environment.apiUrl}/asegurado`; // Ajusta la URL de la API si es necesario

  constructor(private http: HttpClient) { }

  getAsegurados(): Observable<{ data: Asegurado[] }> {
    return this.http.get<{ data: Asegurado[] }>(this.apiUrl);
}

  getAsegurado(id: number): Observable<Asegurado> {
    return this.http.get<Asegurado>(`${this.apiUrl}/${id}`);
  }

  addAsegurado(asegurado: AseguradoNoId): Observable<AseguradoNoId> {
    return this.http.post<AseguradoNoId>(this.apiUrl, asegurado);
  }

  updateAsegurado(asegurado: Asegurado): Observable<Asegurado> {
    return this.http.put<Asegurado>(this.apiUrl, asegurado);
  }

  deleteAsegurado(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getAseguradosByCodigoSeguro(codigoSeguro: string): Observable<Asegurado[]> {
    return this.http.get<Asegurado[]>(`${environment.apiUrl}/asegurado_seguro/asegurados/${codigoSeguro}`);
  }

  uploadAseguradosFile(formData: FormData): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/bulk-upload`, formData);
  }

}
