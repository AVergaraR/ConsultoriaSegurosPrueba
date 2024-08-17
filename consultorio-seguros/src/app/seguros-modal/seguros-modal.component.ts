import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-seguros-modal',
  templateUrl: './seguros-modal.component.html',
  styleUrls: ['./seguros-modal.component.css']
})
export class SegurosModalComponent implements OnInit {
  @Input() seguro: any;
  @Output() close = new EventEmitter<void>();
  @Output() save = new EventEmitter<void>();

  seguroForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.seguroForm = this.fb.group({
      nombre: [
        this.seguro?.nombre || '',
        [Validators.required, Validators.maxLength(40)]
      ],
      codigo: [
        this.seguro?.codigo || '',
        [Validators.required, Validators.maxLength(20)]
      ],
      sumaAsegurada: [
        this.seguro?.sumaAsegurada || '',
        [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]
      ],
      prima: [
        this.seguro?.prima || '',
        [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]
      ],
    });
  }

  onSave() {
    if (this.seguroForm.valid) {
      if(this.seguro.id != 0 && this.seguro.id != null){
        //console.log('emit tiene id' , this.seguro);
        let data = {
          id: this.seguro.id,
          ...this.seguroForm.value
        }
        this.save.emit(data);    

      }else{    
        //console.log('emit no tiene id' , this.seguro);
        //console.log(this.seguroForm.value);
        
        this.save.emit(this.seguroForm.value);         
      }
    }
  }

  onClose() {
    this.close.emit();
  }
}
