import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PessoasRoutingModule } from './pessoas-routing.module';
import { PainelPessoasListComponent } from '../components/painel-pessoas-list/painel-pessoas-list.component';
import { FormularioPessoaComponent } from '../components/formulario-pessoa/formulario-pessoa.component';


@NgModule({
  declarations: [
    PainelPessoasListComponent,
    FormularioPessoaComponent
  ],
  imports: [
    CommonModule,
    PessoasRoutingModule
  ]
})
export class PessoasModule { }
