using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Model
{
    public class PessoaJuridica
    {
        public Guid ID { get; set; }

        public string RazaoSocial { get; set; }

        public string Documento { get; set; }

        public DateTime DataInscricao { get; set; }
        
        public TipoPessoaEnum PessoaTipo { get; set; }

        public IList<Telefone> Telefones { get; set; }

        public IList<InformacaoAdicional> InformacoesAdicionais { get; set; }
    }
}
