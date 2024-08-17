import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { Seguro, SeguroNoId } from './modelos/seguro.model';

@Injectable({
  providedIn: 'root'
})
export class SeguroService {
  private apiUrl = `${environment.apiUrl}/seguro`; 

  constructor(private http: HttpClient) { }

  getSeguros(): Observable<{ data: Seguro[] }> {
    return this.http.get<{ data: Seguro[] }>(this.apiUrl);
  }

  getSeguro(id: number): Observable<Seguro> {
    return this.http.get<Seguro>(`${this.apiUrl}/${id}`);
  }

  addSeguro(seguro: SeguroNoId): Observable<SeguroNoId> {
    return this.http.post<SeguroNoId>(this.apiUrl, seguro);
  }

  updateSeguro(seguro: Seguro): Observable<Seguro> {
    return this.http.put<Seguro>(this.apiUrl, seguro);
  }

  deleteSeguro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getSegurosAsignados(cedula: string): Observable<Seguro[]> {
    return this.http.get<Seguro[]>(`${environment.apiUrl}/asegurado_seguro/seguros/${cedula}`);
  }
  
  getSegurosDisponibles(cedula: string): Observable<{data: Seguro[]}> {
    return this.http.get<{data: Seguro[]}>(`${this.apiUrl}/no_asignados/${cedula}`);
  }
  
  asignarSeguros(AseguradoCedula: string, SeguroCodigo: string[]): Observable<void> {
    return this.http.post<void>(`${environment.apiUrl}/asegurado_seguro/assign`, { AseguradoCedula, SeguroCodigo });
  }

  getSegurosByCedulaAsegurado(cedula: string): Observable<any> {
    return this.http.get<any>(`${environment.apiUrl}/asegurado_seguro/seguros/${cedula}`);
  }
  
}
