using System;
using System.Collections.Generic;
using System.Data;

using SpInfra4Generics.Models.Combobox;
using SpInfra8DataAccess;
using SpInfra8DataAccess.Model;
using SpInfra9Utils;

namespace SpEst3Gerenciamento12.RegraNegocio
{
    public class CategoriasProduto3Rn : DalBaseModel
    {

        #region Constructor

        public CategoriasProduto3Rn(DalBase dalBase)
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

        public List<GUIDRecordCombobox> GetCategoriasCombobox()
        {
            List<GUIDRecordCombobox> recordsList = new List<GUIDRecordCombobox>();

            try
            {
                this._dalBase.Source = Utils.GetMethodDescription(System.Reflection.MethodBase.GetCurrentMethod());

                string command = $@"
                    SELECT		CD_CATEGORIAPRODUTO,
			                    TX_NOME
                    FROM		EST_CATEGORIAPRODUTO
                ";

                this._dalBase.ClearParameters();

                DataTable dataTable = this._dalBase.Query(command);

                if (!this._dalBase.DataTableIsEmpty(dataTable))
                {
                    foreach(DataRow row in dataTable.Rows)
                    {
                        GUIDRecordCombobox record = new GUIDRecordCombobox
                        {
                            ID = this._dalBase.GetColToString(row, "CD_CATEGORIAPRODUTO"),
                            LABEL = this._dalBase.GetColToString(row, "TX_NOME")
                        };
                    }
                }

                return recordsList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion Public Methods

    }
}
