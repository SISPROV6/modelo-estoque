using System;
using System.Runtime.Serialization;

namespace SpEst3Gerenciamento12.RegraNegocio.Models
{
    [DataContract]
    public class PessoasListModel
    {
        [DataMember]
        public long TENANT_ID { get; set; }

        [DataMember]
        public string ID_PESSOA { get; set; }

        [DataMember]
        public string TX_NOMEPESSOA { get; set; }

        [DataMember]
        public string TIPOPESSOA_CD { get; set; }

        [DataMember]
        public string PAPEL_CD { get; set; }

        [DataMember]
        public string TX_DOCUMENTO { get; set; }

        [DataMember]
        public DateTime? DT_NASCIMENTO { get; set; }

        [DataMember]
        public DateTime? DT_FUNDACAO { get; set; }

        [DataMember]
        public DateTime DT_INICIOVINCULO { get; set; }

        [DataMember]
        public DateTime DT_CRIACAO { get; set; }

        [DataMember]
        public DateTime DT_ULTIMAALTERACAO { get; set; }

        [DataMember]
        public bool IS_ACTIVE { get; set; }

        [DataMember]
        public bool IS_ESTRANGEIRO { get; set; }

        public PessoasListModel()
        {
            TENANT_ID = 0;
            ID_PESSOA = string.Empty;
            TX_NOMEPESSOA = string.Empty;
            TIPOPESSOA_CD = string.Empty;
            PAPEL_CD = string.Empty;
            TX_DOCUMENTO = string.Empty;
            DT_NASCIMENTO = null;
            DT_FUNDACAO = null;
            DT_INICIOVINCULO = DateTime.Now;
            DT_CRIACAO = DateTime.Now;
            DT_ULTIMAALTERACAO = DateTime.Now;
            IS_ACTIVE = true;
            IS_ESTRANGEIRO = false;
        }
    }
}
