
using System;

namespace SpEst3Gerenciamento12.RegraNegocio.Models
{
    public class PessoasListModel
    {
		public long TENANT_ID = 0;
		public string ID_PESSOA = "";
		public string TX_NOMEPESSOA = "";
		public string TIPOPESSOA_CD = "";
		public string PAPEL_CD = "";
		public string TX_DOCUMENTO = "";
		public DateTime DT_NASCIMENTO = DateTime.Now;
		public DateTime DT_FUNDACAO = DateTime.Now;
		public DateTime DT_INICIOVINCULO = DateTime.Now;
		public DateTime DT_CRIACAO = DateTime.Now;
		public DateTime DT_ULTIMAALTERACAO = DateTime.Now;
		public bool IS_ACTIVE = true;
		public bool IS_ESTRANGEIRO = false;
    }
}
