using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.Model
{
    public class PessoaFisica
    {
        public Guid ID { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Obito { get; set; }

        public TipoPessoaEnum PessoaTipo { get; set; }

        public IQueryable<InformacaoAdicional> InformacoesAdicionais { get; set; }

        public IQueryable<Telefone> Telefone { get; set; }
    }
}
