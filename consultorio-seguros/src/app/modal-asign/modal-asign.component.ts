import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Seguro } from '../modelos/seguro.model'; // Asegúrate de que la ruta sea la correcta
import { SeguroService } from '../seguro.service'; // Asegúrate de que la ruta sea la correcta

@Component({
  selector: 'app-modal-seguros',
  templateUrl: './modal-asign.component.html',
  styleUrls: ['./modal-asign.component.css']
})
export class ModalAsignComponent implements OnInit {
  @Input() cedula!: string;
  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<string[]>();

  segurosDisponibles: Seguro[] = [];
  segurosAsignados: Seguro[] = [];
  segurosSeleccionados: { [codigo: string]: boolean } = {};

  constructor(private seguroService: SeguroService) {}

  ngOnInit(): void {
    this.loadSeguros();
  }

  loadSeguros(): void {
    
    this.seguroService.getSegurosDisponibles(this.cedula).subscribe(data => {
      this.segurosDisponibles = data.data;
    });

    this.seguroService.getSegurosAsignados(this.cedula).subscribe(data => {
      this.segurosAsignados = data;
    });
  }

  saveSeguros(): void {

    //console.log('Seleccionados ',this.segurosSeleccionados);
    const segurosAAsignar = Object.keys(this.segurosSeleccionados)
      .filter(codigo => this.segurosSeleccionados[codigo]);

    //console.log('Seleccionados formateados ',segurosAAsignar);   
    //console.log('cedula ',this.cedula.toString());   
    if(segurosAAsignar.length == 0){
      return;
    }

    this.seguroService.asignarSeguros(this.cedula, segurosAAsignar).subscribe(() => {
      this.loadSeguros(); 
    });
  }

  closeSegurosModal(): void {
    this.close.emit();
  }

  toggleSeguro(codigo: string): void {
    this.segurosSeleccionados[codigo] = !this.segurosSeleccionados[codigo];
  }
}
