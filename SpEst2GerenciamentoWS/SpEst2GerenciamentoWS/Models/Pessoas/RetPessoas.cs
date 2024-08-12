using System.Collections.Generic;
using SpInfra5WSUtils.Model;
using SpEstGerenciamento7Db.Database;
using System.Runtime.Serialization;

namespace SpEst2GerenciamentoWS.Models.Pessoas
{
    public class RetPessoas : ReturnModel<List<EstPessoaRecord>>
    {
        [DataMember(Name = "Pessoas")]
        public override List<EstPessoaRecord> Data { get; set; }
    }
}