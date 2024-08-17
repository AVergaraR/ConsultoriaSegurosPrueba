import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AseguradosComponent } from './asegurados/asegurados.component';
import { ModalComponent } from './modal/modal.component';
import { AppRoutingModule } from './app-routing.module';
import { SegurosComponent } from './seguros/seguros.component';
import { SegurosModalComponent } from './seguros-modal/seguros-modal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalAsignComponent } from './modal-asign/modal-asign.component'; // 

@NgModule({
  declarations: [
    AppComponent,
    AseguradosComponent,
    ModalComponent,
    SegurosComponent,
    SegurosModalComponent,
    ModalAsignComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
