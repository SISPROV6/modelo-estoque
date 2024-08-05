using System.Collections.Generic;
using System.Runtime.Serialization;
using SpEst3Gerenciamento12.RegraNegocio.Models;
using SpInfra5WSUtils.Model;

namespace SpEst2GerenciamentoWS.Models.Pessoas
{
    public class RetPessoasListModel : ReturnModel<List<PessoasListModel>>
    {
        [DataMember(Name = "PessoasList")]
        public override List<PessoasListModel> Data { get; set; }

        [DataMember]
        public ContagemPessoasCards contagemPessoasCards { get; set; }
    }
}