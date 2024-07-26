import { EventEmitter, Injectable, Input, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PessoasService {

  constructor() { }







  // class="col-{TAMANHO}"
  public headers: { NOME: string, LARGURA: number }[] = [
    { NOME: "Modelo", LARGURA: 4 }
  ];
  
  public hasActions: boolean = false;

  @Input() public actions: { ACAO: string, CONTEUDO: string | number, ICONE: string }[] = [];

  // Mesma quantidade das colunas, texto puro ou HTML
  public content: string[] = [
    "<div> <p>LINHA 1</p> <p>LINHA 2</p> </div>"
  ];


}
