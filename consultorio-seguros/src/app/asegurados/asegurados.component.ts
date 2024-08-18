import { Component, OnInit, Input } from '@angular/core';
import { AseguradoService } from '../asegurado.service';
import { SeguroService } from '../seguro.service';
import { Asegurado, AseguradoNoId } from '../modelos/asegurado.model';

@Component({
  selector: 'app-asegurados',
  templateUrl: './asegurados.component.html',
  styleUrls: ['./asegurados.component.css']
})

export class AseguradosComponent implements OnInit {

  selectedAsegurado: Asegurado = {
    id: 0,
    cedula: '',
    nombre: '',
    telefono: '',
    edad: 0
  };
  aseguradoNoId: AseguradoNoId = {
    cedula: '',
    nombre: '',
    telefono: '',
    edad: 0
  }
  codigoSeguro: string = '';
  showModal: boolean = false;
  showModalAsign: boolean = false;
  asegurados: Asegurado[] = [];
  selectedCedula: string = '';
  loading: boolean = false;

  constructor(private aseguradoService: AseguradoService, private seguroService: SeguroService) { }


  ngOnInit(): void {
    this.loadAsegurados();
  }

  loadAsegurados() {
    this.aseguradoService.getAsegurados().subscribe(data => {
      this.asegurados = data.data;
    });
  }

  openModal(asegurado: Asegurado | null = null) { 
    this.selectedAsegurado = asegurado ? { ...asegurado } : {
      id: 0,
      cedula: '',
      nombre: '',
      telefono: '',
      edad: 0
    };
  
    this.showModal = true;
  }

  openModalAsign(cedula: string): void {
    this.selectedCedula = cedula;
    this.showModalAsign = true;
  }

  saveSegurosAsignados(seguros: string[]): void {
    this.seguroService.asignarSeguros(this.selectedCedula, seguros).subscribe(() => {
      this.loadAsegurados();
    });
  }

  closeModal() {
    this.showModal = false;
  }

  closeModalAsign() {
    this.showModalAsign = false;
  }

  saveAsegurado(asegurado: any) {

    if (asegurado.id) {
     
      this.aseguradoService.updateAsegurado(asegurado).subscribe(() => {
        this.loadAsegurados();
        this.closeModal();
      });
    } else {
      
      this.aseguradoService.addAsegurado(asegurado).subscribe(() => {
        this.loadAsegurados();
        this.closeModal();
      });
    }
  }

  buscarPorCodigoSeguro() {
    if (this.codigoSeguro.trim() !== '') {
      this.aseguradoService.getAseguradosByCodigoSeguro(this.codigoSeguro).subscribe(data => {    
        this.asegurados = data;
        console.log(this.asegurados);
      });
    }
  }

  resetBusqueda() {
    this.codigoSeguro = '';
    this.loadAsegurados();
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    
    if (file && file.type === 'text/plain') {  
      // Validar el contenido del archivo (encabezado)
      this.validateFileContent(file)
        .then(isValid => {
          if (isValid) {
            this.uploadFile(file);
          } else {
            alert('El encabezado del archivo es incorrecto. Debe ser: Cedula,Nombre,Telefono,Edad');
          }
        });
    } else {
      alert('Por favor, selecciona un archivo .txt.');
    }
  }

  validateFileContent(file: File): Promise<boolean> {
    const reader = new FileReader();
    return new Promise((resolve) => {
      reader.onload = () => {
        const content = reader.result as string;
        const header = content.split('\n')[0].trim();
        const expectedHeader = 'Cedula,Nombre,Telefono,Edad';
        console.log('header', header);
        resolve(header == expectedHeader);
      };
      reader.readAsText(file);
    });
  }

  uploadFile(file: File) {
    this.loading = true;
    const formData = new FormData();
    formData.append('file', file);
    //return;
    this.aseguradoService.uploadAseguradosFile(formData).subscribe({
      next: () => {
        this.loading = false;
        alert('Archivo cargado exitosamente.');
        this.loadAsegurados();  
      },
      error: (err) => {
        this.loading = false;
        alert('Error al cargar el archivo.');
        console.error(err);
      }
    });
  }

  idAseguradoElim: number = 0;
  aseguradoNombreElim: string = '';
  showAseguradoElimModal: boolean = false;


  openAseguradoElimModal(id: number, nombre: string) {
    this.idAseguradoElim = id;
    this.aseguradoNombreElim = nombre;
    this.showAseguradoElimModal = true;
  }

  closeAseguradoElimModal() {
    this.idAseguradoElim = 0;
    this.aseguradoNombreElim = '';
    this.showAseguradoElimModal = false;
  }

  
  deleteAsegurado() {
    this.aseguradoService.deleteAsegurado(this.idAseguradoElim).subscribe(() => {
      this.loadAsegurados();
    });
  }


}
