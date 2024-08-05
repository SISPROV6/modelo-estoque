using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SpEst3Gerenciamento12.RegraNegocio.Models;
using SpEstGerenciamento7Db.Database;
using SpInfra4Generics.Generics.Models;
using SpInfra4Generics.Models.Combobox;
using SpInfra8DataAccess;
using SpInfra8DataAccess.Model;
using SpInfra9Utils;
using SpInfra9Utils.Session;

namespace SpEst3Gerenciamento12.RegraNegocio
{
    public class Pessoas3Rn : DalBaseModel
    {

        #region Constructor

        public Pessoas3Rn(DalBase dalBase)
        {
            this._dalBase = dalBase;
        }

        #endregion Constructor

        #region IDalBaseModel

        protected override DalBase _dalBase { get; }

        #endregion IDalBaseModel

        #region Public Properties

        #endregion Public Properties

        #region Public Methods

        #region GET
        public List<PessoasListModel> GetPessoasList(PessoasFilters pessoasFilters, out ContagemPessoasCards contagemPessoasCards)
        {
            List<PessoasListModel> recordsList = new List<PessoasListModel>();
            contagemPessoasCards = new ContagemPessoasCards();

            try
            {
                this._dalBase.Source = Utils.GetMethodDescription(System.Reflection.MethodBase.GetCurrentMethod());

                string command = $@"
                    SELECT		TENANT_ID,
                                ID_PESSOA,
                                TX_NOMEPESSOA,
                                TIPOPESSOA_CD,
                                PAPEL_CD,
                                TX_DOCUMENTO,
                                DT_NASCIMENTO,
                                DT_FUNDACAO,
                                DT_INICIOVINCULO,
                                DT_CRIACAO,
                                DT_ULTIMAALTERACAO,
                                IS_ACTIVE,
                                IS_ESTRANGEIRO

                    FROM		EST_PESSOA
                    WHERE		TENANT_ID = @TenantID
                      AND		(	TX_NOMEPESSOA LIKE @Pesquisa OR
				                    TX_DOCUMENTO LIKE @Pesquisa )

                    {( pessoasFilters.TIPO == "" || pessoasFilters.TIPO == null ? "" : "AND     TIPOPESSOA_CD = @TipoPessoa" )}
                    {( pessoasFilters.PAPEL == "" || pessoasFilters.PAPEL == null ? "" : "AND   PAPEL_CD = @PapelPessoa")}

                      AND       IS_ACTIVE = @IsAtivo
                ";

                this._dalBase.ClearParameters();

                this._dalBase.CreateParameter("@TenantID", DbType.Int64, ApplicationSession.Get.TenantId);
                this._dalBase.CreateParameter("@Pesquisa", DbType.String, $"%{pessoasFilters.TEXTO_PESQUISA}%");
                this._dalBase.CreateParameter("@IsAtivo", DbType.Boolean, pessoasFilters.IS_ATIVO);
                this._dalBase.CreateParameter("@TipoPessoa", DbType.String, pessoasFilters.TIPO);
                this._dalBase.CreateParameter("@PapelPessoa", DbType.String, pessoasFilters.PAPEL);

                DataTable dataTable = this._dalBase.Query(command);

                if (!this._dalBase.DataTableIsEmpty(dataTable))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        PessoasListModel record = new PessoasListModel
                        {
                            TENANT_ID = this._dalBase.GetColToLong(row, "TENANT_ID"),
                            ID_PESSOA = this._dalBase.GetColToString(row, "ID_PESSOA"),
                            TX_NOMEPESSOA = this._dalBase.GetColToString(row, "TX_NOMEPESSOA"),
                            TIPOPESSOA_CD = this._dalBase.GetColToString(row, "TIPOPESSOA_CD"),
                            PAPEL_CD = this._dalBase.GetColToString(row, "PAPEL_CD"),
                            TX_DOCUMENTO = this._dalBase.GetColToString(row, "TX_DOCUMENTO"),
                            DT_NASCIMENTO = this._dalBase.GetColToDateTime(row, "DT_NASCIMENTO"),
                            DT_FUNDACAO = this._dalBase.GetColToDateTime(row, "DT_FUNDACAO"),
                            DT_INICIOVINCULO = this._dalBase.GetColToDateTime(row, "DT_INICIOVINCULO"),
                            DT_CRIACAO = this._dalBase.GetColToDateTime(row, "DT_CRIACAO"),
                            DT_ULTIMAALTERACAO = this._dalBase.GetColToDateTime(row, "DT_ULTIMAALTERACAO"),
                            IS_ACTIVE = this._dalBase.GetColToBoolean(row, "IS_ACTIVE"),
                            IS_ESTRANGEIRO = this._dalBase.GetColToBoolean(row, "IS_ESTRANGEIRO")
                        };

                        recordsList.Add(record);

                        contagemPessoasCards.TOTAL++;
                        switch(this._dalBase.GetColToString(row, "PAPEL_CD"))
                        {
                            case "FOR": contagemPessoasCards.FORNECEDOR++; break;
                            case "CLI": contagemPessoasCards.CLIENTE++; break;
                            case "FUNC": contagemPessoasCards.FUNCIONARIO++; break;
                        }
                    }
                }

                return recordsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GUIDRecordCombobox> GetPessoasCombobox(string pesquisa)
        {
            List<GUIDRecordCombobox> recordsList = new List<GUIDRecordCombobox>();

            try
            {
                this._dalBase.Source = Utils.GetMethodDescription(System.Reflection.MethodBase.GetCurrentMethod());

                string command = $@"
                    SELECT		ID_PESSOA,
			                    TX_NOMEPESSOA,
			                    TX_DOCUMENTO,
			                    TIPOPESSOA_CD

                    FROM		EST_PESSOA
                    WHERE		TENANT_ID = @TenantID
                      AND		(	TX_NOMEPESSOA LIKE @Pesquisa OR
				                    TX_DOCUMENTO LIKE @Pesquisa )
                      AND       IS_ACTIVE = 1
                ";

                this._dalBase.ClearParameters();

                this._dalBase.CreateParameter("@TenantID", DbType.Int64, ApplicationSession.Get.TenantId);
                this._dalBase.CreateParameter("@Pesquisa", DbType.String, $"%{pesquisa}%");

                DataTable dataTable = this._dalBase.Query(command);

                if (!this._dalBase.DataTableIsEmpty(dataTable))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GUIDRecordCombobox record = new GUIDRecordCombobox
                        {
                            ID = this._dalBase.GetColToString(row, "ID_PESSOA"),
                            LABEL = this._dalBase.GetColToString(row, "TX_NOMEPESSOA"),
                            AdditionalStringProperty1 = this._dalBase.GetColToString(row, "TX_DOCUMENTO"),
                            AdditionalStringProperty2 = this._dalBase.GetColToString(row, "TIPOPESSOA_CD"),
                        };

                        recordsList.Add(record);
                    }
                }

                return recordsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GUIDRecordCombobox> GetPapeisPessoaCombobox(string pesquisa)
        {
            List<GUIDRecordCombobox> recordsList = new List<GUIDRecordCombobox>();

            try
            {
                this._dalBase.Source = Utils.GetMethodDescription(System.Reflection.MethodBase.GetCurrentMethod());

                string command = $@"
                    SELECT		CD_PAPEL,
			                    TX_NOME
                    FROM		EST_PAPEL
                    WHERE		TX_NOME LIKE @Pesquisa
                    ORDER BY	TX_NOME ASC
                ";

                this._dalBase.ClearParameters();
                this._dalBase.CreateParameter("@Pesquisa", DbType.String, $"%{pesquisa}%");

                DataTable dataTable = this._dalBase.Query(command);

                if (!this._dalBase.DataTableIsEmpty(dataTable))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        GUIDRecordCombobox record = new GUIDRecordCombobox
                        {
                            ID = this._dalBase.GetColToString(row, "CD_PAPEL"),
                            LABEL = this._dalBase.GetColToString(row, "TX_NOME")
                        };

                        recordsList.Add(record);
                    }
                }

                return recordsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion GET

        #endregion Public Methods

    }
}
