using System;
using System.Collections.Generic;
using System.Data;
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
        public List<EstPessoaRecord> GetPessoasList(BasicFilters basicFilters)
        {
            List<EstPessoaRecord> recordsList = new List<EstPessoaRecord>();

            try
            {
                this._dalBase.Source = Utils.GetMethodDescription(System.Reflection.MethodBase.GetCurrentMethod());

                string command = $@"
                    SELECT		TENANT_ID,
                                ID_PESSOA,
			                    TX_NOMEPESSOA,
			                    TX_DOCUMENTO,
			                    TIPOPESSOA_CD

                    FROM		EST_PESSOA
                    WHERE		TENANT_ID = @TenantID
                      AND		(	TX_NOMEPESSOA LIKE @Pesquisa OR
				                    TX_DOCUMENTO LIKE @Pesquisa )
                      AND       IS_ACTIVE = @IsAtivo
                ";

                this._dalBase.ClearParameters();

                this._dalBase.CreateParameter("@TenantID", DbType.Int64, ApplicationSession.Get.TenantId);
                this._dalBase.CreateParameter("@Pesquisa", DbType.String, basicFilters.TEXTO_PESQUISA);
                this._dalBase.CreateParameter("@IsAtivo", DbType.Boolean, basicFilters.IS_ATIVO);

                DataTable dataTable = this._dalBase.Query(command);

                if (!this._dalBase.DataTableIsEmpty(dataTable))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        EstPessoaRecord record = new EstPessoaRecord
                        {
                            ID_PESSOA = this._dalBase.GetColToString(row, "ID_PESSOA"),
                            TX_NOMEPESSOA = this._dalBase.GetColToString(row, "TX_NOMEPESSOA"),
                            TENANT_ID = this._dalBase.GetColToLong(row, "TENANT_ID"),
                            IS_ACTIVE = this._dalBase.GetColToBoolean(row, "IS_ACTIVE"),
                        };
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
