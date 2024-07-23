using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpInfra4Generics.Models.Combobox;
using SpInfra8DataAccess;
using SpInfra8DataAccess.Model;

namespace SpEst3Gerenciamento.RegraNegocio
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



        #endregion Public Methods

    }
}
