using System.Runtime.Serialization;

namespace SpEst3Gerenciamento12.RegraNegocio.Models
{
    [DataContract]
    public class ContagemPessoasCards
    {
        [DataMember]
        public long TOTAL { get; set; }

        [DataMember]
        public long FORNECEDOR { get; set; }

        [DataMember]
        public long CLIENTE { get; set; }

        [DataMember]
        public long FUNCIONARIO { get; set; }


        public ContagemPessoasCards()
        {
            this.TOTAL = 0;
            this.FORNECEDOR = 0;
            this.CLIENTE = 0;
            this.FUNCIONARIO = 0;
        }
    }
}
