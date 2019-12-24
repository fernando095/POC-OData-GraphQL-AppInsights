using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POC.Model;

namespace POC.Model.Generator
{
    public static class DataGenerator
    {
        public static IQueryable<PessoaFisica> GeneratePessoaFisica()
        {
            IList<PessoaFisica> pessoasFisicas = new List<PessoaFisica>();

            InformacaoAdicional informacaoAdicional = new InformacaoAdicional()
            {
                Nome = "Sabe oque eh Geba?",
                Valor = "Nao sabe"
            };

            InformacaoAdicional informacaoAdicional2 = new InformacaoAdicional()
            {
                Nome = "Motivo do obito",
                Valor = "Katana nele"
            };

            List<InformacaoAdicional> informacoesAdicionais = new List<InformacaoAdicional>();

            informacoesAdicionais.Add(informacaoAdicional);
            informacoesAdicionais.Add(informacaoAdicional2);
            IList<Telefone> telefones = new List<Telefone>();
            telefones.Add(new Telefone()
            {
                ID = Guid.NewGuid(),
                DDD = "45",
                Numero = "922346577"
            });
            pessoasFisicas.Add(new PessoaFisica()
            {
                ID = Guid.NewGuid(),
                DataNascimento = new DateTime(1976, 09, 28),
                Documento = "02999933323",
                Nome = "Matheux Ximenex",
                Obito = true,
                PessoaTipo = TipoPessoaEnum.PessoaTipo1,
                Telefone = telefones.AsQueryable(),
                InformacoesAdicionais = informacoesAdicionais.AsQueryable(),

            });

            IList<Telefone> telefones2 = new List<Telefone>();
            telefones2.Add(new Telefone()
            {
                ID = Guid.NewGuid(),
                DDD = "17",
                Numero = "70707070"
            });

            pessoasFisicas.Add(new PessoaFisica()
            {
                ID = Guid.NewGuid(),
                DataNascimento = new DateTime(1976, 09, 28),
                Documento = "02999933323",
                Nome = "Robersval Cacheado",
                Obito = true,
                PessoaTipo = TipoPessoaEnum.PessoaTipo1,
                Telefone = telefones2.AsQueryable(),
                InformacoesAdicionais = new List<InformacaoAdicional>().AsQueryable(),

            });

            return pessoasFisicas.AsQueryable();
        }

        public static PessoaJuridica GeneratePessoaJuridica()
        {
            

            InformacaoAdicional informacaoAdicional = new InformacaoAdicional()
            {
                Nome = "Ta pra falir?",
                Valor = "Eh Provável"
            };

            List<InformacaoAdicional> informacoesAdicionais = new List<InformacaoAdicional>();

            informacoesAdicionais.Add(informacaoAdicional);
            List<Telefone> telefones = new List<Telefone>();
            telefones.Add(new Telefone()
            {
                ID = Guid.NewGuid(),
                DDD = "10",
                Numero = "22049993"
            });
            return new PessoaJuridica()
            {
                ID = Guid.NewGuid(),
                DataInscricao = DateTime.Now,
                Documento = "95873354502",
                RazaoSocial = "Empresa de Teste",
                PessoaTipo = TipoPessoaEnum.PessoaTipo2,
                Telefones = telefones,
                InformacoesAdicionais = informacoesAdicionais,

            };
        }

        public static IQueryable<Telefone> GenerateTelefone()
        {
            IList<Telefone> telefones = new List<Telefone>();
            telefones.Add(new Telefone()
            {
                ID = Guid.NewGuid(),
                DDD = "45",
                Numero = "922346577"
            });
            return telefones.AsQueryable();
        }
    }
}
