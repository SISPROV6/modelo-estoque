using System;
using System.Collections.Generic;
using System.Data;

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
                    --WHERE		TENANT_ID = @TenantID
                      WHERE		(	TX_NOMEPESSOA LIKE @Pesquisa OR
				                    TX_DOCUMENTO LIKE @Pesquisa )
                ";

                this._dalBase.ClearParameters();

                this._dalBase.CreateParameter("@TenantID", DbType.Int64, ApplicationSession.Get.TenantId);
                this._dalBase.CreateParameter("@Pesquisa", DbType.String, pesquisa);

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
                    }
                }

                return recordsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Methods

    }
}
