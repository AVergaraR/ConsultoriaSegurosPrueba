export interface Seguro {
    id: number;
    nombre: string;
    codigo: string;
    sumaAsegurada: number;
    prima: number;
  }

export interface SeguroNoId {
nombre: string;
codigo: string;
sumaAsegurada: number;
prima: number;
}  