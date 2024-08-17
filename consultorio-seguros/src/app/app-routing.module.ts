import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AseguradosComponent } from './asegurados/asegurados.component';
import { SegurosComponent } from './seguros/seguros.component'; // Asegúrate de importar el componente de Seguros

const routes: Routes = [
  { path: 'asegurados', component: AseguradosComponent },
  { path: 'seguros', component: SegurosComponent },
  { path: '', redirectTo: '/asegurados', pathMatch: 'full' } // Ruta predeterminada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
