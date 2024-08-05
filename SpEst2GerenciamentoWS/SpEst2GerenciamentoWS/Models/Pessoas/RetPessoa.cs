using System.Runtime.Serialization;
using SpInfra5WSUtils.Model;
using SpEstGerenciamento7Db.Database;

namespace SpEst2GerenciamentoWS.Models.Pessoas
{
    public class RetPessoa : ReturnModel<EstPessoaRecord>
    {
        [DataMember(Name = "PessoaRecord")]
        public override EstPessoaRecord Data { get; set; }
    }
}