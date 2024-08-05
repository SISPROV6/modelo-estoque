using System.Runtime.Serialization;
using SpInfra4Generics.Generics.Models;

namespace SpEst3Gerenciamento12.RegraNegocio.Models
{
    [DataContract]
    public class PessoasFilters : BasicFilters
    {
        [DataMember]
        public string PAPEL { get; set; }

        [DataMember]
        public string TIPO { get; set; }

        public PessoasFilters()
        {
            TEXTO_PESQUISA = "";
            IS_ATIVO = true;
            PAPEL = null;
            TIPO = null;
        }
    }
}
