import { Component, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { MessageService } from 'ngx-sp-infra';
import { PessoasService } from '../../services/pessoas.service';
import { ProjectUtilservice } from 'src/app/project/utils/project-utils.service';
import { RecordCombobox } from 'src/app/project/models/combobox/record-combobox';

@Component({
  selector: 'formulario-pessoa',
  templateUrl: './formulario-pessoa.component.html',
  styleUrl: './formulario-pessoa.component.scss'
})
export class FormularioPessoaComponent implements OnInit {
  constructor(
    private _bsModalService: BsModalService,
    private _messageService: MessageService,
    private _pessoasService: PessoasService,
    private _projectUtilService: ProjectUtilservice
  ) { }

  public ngOnInit(): void {
    this.getPessoasCombobox("");
    this.getPapeisPessoaCombobox("");
  }

  // #region ==========> PROPERTIES <==========

  // #region PRIVATE
  // [...]
  // #endregion PRIVATE

  // #region PUBLIC
  public $pessoasCombobox: RecordCombobox[] = [];
  public $papeisCombobox: RecordCombobox[] = [];

  public selectedPessoa: string;
  public selectedPapel: string;
  // #endregion PUBLIC

  // #endregion ==========> PROPERTIES <==========


  // #region ==========> FORM BUILDER <==========

  // #region FORM DATA
  // [...]
  // #endregion FORM DATA

  // #region FORM VALIDATORS
  // [...]
  // #endregion FORM VALIDATORS

  // #endregion ==========> FORM BUILDER <==========


  // #region ==========> SERVICE METHODS <==========

  // #region PREPARATION
  public getPessoasCombobox(pesquisa: string): void {
    this._pessoasService.getPessoasCombobox(pesquisa).subscribe({
      next: response => {
        this.$pessoasCombobox = response.Records;
      },
      error: error => { this._projectUtilService.showHttpError(error) }
    });
  }
  public getPapeisPessoaCombobox(pesquisa: string): void {
    this._pessoasService.getPapeisPessoaCombobox(pesquisa).subscribe({
      next: response => {
        this.selectedPapel = "FOR";   // Definindo um valor prévio
        
        this.$papeisCombobox = response.Records;
      },
      error: error => { this._projectUtilService.showHttpError(error) }
    });
  }
  // #endregion PREPARATION

  // #region GET
  // [...]
  // #endregion GET

  // #region POST
  // [...]
  // #endregion POST

  // #region DELETE
  // [...]
  // #endregion DELETE

  // #endregion ==========> SERVICE METHODS <==========


  // #region ==========> UTILITIES <==========
  public setOtherValue(): void {
    this.selectedPapel = "FUNC";
  }
  // #endregion ==========> UTILITIES <==========


  // #region ==========> MODALS <==========
  // [...]
  // #endregion ==========> MODALS <==========

}
