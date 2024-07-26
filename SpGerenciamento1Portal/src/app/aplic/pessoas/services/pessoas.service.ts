import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, take, tap } from 'rxjs';
import { RetError } from 'ngx-sp-infra';

import { environment } from 'src/environments/environment';
import { BasicFilters } from 'src/app/project/models/basic-filters';
import { RetRecordsCombobox } from 'src/app/project/models/combobox/ret-records-combobox';

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  constructor(private _httpClient: HttpClient) {
    this._BASE_URL = !environment.production ? this._BASE_URL : `${ environment.Sp2LocalhostWS }/Pessoas`;
  }

  // #region ==========> PROPERTIES <==========

  // #region PRIVATE
  private readonly _BASE_URL: string = `${ environment.Sp2LocalhostWS }/Pessoas`;  // SpEst2GerenciamentoWS
  private readonly _HTTP_HEADERS = new HttpHeaders().set('Content-Type', 'application/json');
  // #endregion PRIVATE

  // #endregion ==========> PROPERTIES <==========


  // #region ==========> SERVICE METHODS <==========

  // #region PREPARATION

  /** INCOMPLETO */
  public getPessoasList(basicFilters: BasicFilters): Observable<RetError> {
    const params = new HttpParams()
      .set('isAtivo', basicFilters.IS_ATIVO)
      .set('pesquisa', basicFilters.TEXTO_PESQUISA);
    
    const headers = this._HTTP_HEADERS;
    
    const url = `${ this._BASE_URL }/GetPessoasList`;

    return this._httpClient.get<RetError>(url, { 'params': params, 'headers': headers })
      .pipe(take(1), tap(response => this.showErrorMessage(response)) );
  }
  // #endregion PREPARATION

  // #region GET
  public getPessoasCombobox(pesquisa: string): Observable<RetRecordsCombobox> {
    const params = new HttpParams().set('pesquisa', pesquisa);

    const headers = this._HTTP_HEADERS;
    
    const url = `${ this._BASE_URL }/GetPessoasCombobox`;

    return this._httpClient.get<RetRecordsCombobox>(url, { 'params': params, 'headers': headers })
      .pipe(take(1), tap(response => this.showErrorMessage(response)) );
  }
  // #endregion GET

  // #region POST
  // [...]
  // #endregion POST

  // #region DELETE
  // [...]
  // #endregion DELETE

  // #endregion ==========> SERVICE METHODS <==========


  // #region ==========> UTILITIES <==========
  private showErrorMessage(response: RetError): void { if (response.Error) throw Error(response.ErrorMessage); }
  // #endregion ==========> UTILITIES <==========

}
