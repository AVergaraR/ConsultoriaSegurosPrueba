import { Component, OnInit } from '@angular/core';
import { SeguroService } from '../seguro.service';
import { Seguro } from '../modelos/seguro.model';

@Component({
  selector: 'app-seguros',
  templateUrl: './seguros.component.html',
  styleUrls: ['./seguros.component.css']
})
export class SegurosComponent implements OnInit {
  seguros: Seguro[] = [];
  selectedSeguro: Seguro = {
    id: 0,
    nombre: '',
    codigo: '',
    sumaAsegurada: 0,
    prima: 0
  };
  showModal: boolean = false;
  cedulaAsegurado: string = '';

  constructor(private seguroService: SeguroService) { }

  ngOnInit(): void {
    this.loadSeguros();
  }

  loadSeguros() {
    this.seguroService.getSeguros().subscribe(data => {
      this.seguros = data.data;
    });
  }

  openModal(seguro: Seguro | null = null) {
    this.selectedSeguro = seguro ? { ...seguro } : {
      id: 0,
      nombre: '',
      codigo: '',
      sumaAsegurada: 0,
      prima: 0
    };
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }

  saveSeguro(seguro: any) {
    if (seguro.id) {
      //console.log('tiene id' , seguro);
      this.seguroService.updateSeguro(seguro).subscribe(() => {
        this.loadSeguros();
        this.closeModal();
      });
    } else {
      //console.log('no tiene id' , seguro);
      this.seguroService.addSeguro(seguro).subscribe(() => {
        this.loadSeguros();
        this.closeModal();
      });
    }
  }

  deleteSeguro(id: number) {
    this.seguroService.deleteSeguro(id).subscribe(() => {
      this.loadSeguros();
    });
  }

  buscarPorCedulaAsegurado() {
    if (this.cedulaAsegurado.trim() !== '') {
      this.seguroService.getSegurosByCedulaAsegurado(this.cedulaAsegurado).subscribe(data => {
        this.seguros = data;
      });
    }
  }

  resetBusqueda() {
    this.cedulaAsegurado = '';
    this.loadSeguros();
  }


}
