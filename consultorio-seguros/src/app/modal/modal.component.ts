import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule, ReactiveFormsModule, AbstractControl, FormBuilder, FormGroup, Validators, ValidationErrors, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @Input() asegurado: any;
  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<void>();

  aseguradoForm: FormGroup;


  
  constructor(private fb: FormBuilder) {

    // Función de validación personalizada para cedula y telefono
    function validarNum(): ValidatorFn {
      return (control: AbstractControl): ValidationErrors | null => {
        const num = control.value;      
        if (!num) {   
          return null;
        }
        if (num.length !== 10) {
          return { numeroInvalido: true };
        }
        return null;
      };
    }

    function validarEdad(): ValidatorFn {
      return (control: AbstractControl): ValidationErrors | null => {
        const val = parseInt(control.value);  
   
        if (!val || val == 0) {   
          return { edadInvalida: true };
        }
        if (val < 18 || val > 110) {
          return { edadInvalida: true };
        }
        return null;
      };
    }

    this.aseguradoForm = this.fb.group({
      cedula: ['', [Validators.required, validarNum()]],
      nombre: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]{1,20}$')]],
      telefono: ['', [Validators.required, validarNum()]],
      edad: [18, [Validators.required, validarEdad()]]
    });
  }

  ngOnChanges() {
    if (this.asegurado) {
      this.aseguradoForm.patchValue(this.asegurado);
    }
  }

  onSave() {
    if (this.aseguradoForm.valid) {
      
      if(this.asegurado.id != 0){
        let data = {
          id: this.asegurado.id,
          ...this.aseguradoForm.value
        }
        this.save.emit(data);    

      }else{    
        this.save.emit(this.aseguradoForm.value);         
      }
       
    }
  }

  onClose() {
    this.close.emit();
  }
}
