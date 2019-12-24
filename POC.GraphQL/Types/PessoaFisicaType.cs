using GraphQL.Types;
using POC.Model;
using POC.Model.Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.GraphQL.Types
{
    public class PessoaFisicaType : ObjectGraphType<PessoaFisica>
    {
        public PessoaFisicaType()
        {
            Name = "PessoaFisica";
            Field(x => x.ID, type: typeof(IdGraphType)).Description("ID da PessoaFisica");
            Field(x => x.Nome).Description("Nome da PessoaFisica");
            Field(x => x.Documento).Description("Documento da PessoaFisica");
            Field(x => x.Obito).Description("PessoaFisica possui obito?");
            //Field(typeof(ListGraphType<TelefoneType>), "Telefone", resolve: context => DataGenerator.GenerateTelefone()).Description("Telefone da PessoaFisica");
            //Field<ListGraphType<TelefoneType>>("telefone", resolve: context => DataGenerator.GenerateTelefone());
            Field(typeof(ListGraphType<TelefoneType>), "telefone", resolve: context => DataGenerator.GenerateTelefone());
            //Field(x => x.Telefone, type: typeof(ComplexGraphType<TelefoneType>)).Resolve(context => DataGenerator.GenerateTelefone()).Description("Telefones da PessoaFisica");
            //Field(x => x.InformacoesAdicionais).Description("Informações adicionais da PessoaFisica");
            Field(x => x.DataNascimento, type: typeof(DateGraphType)).Description("Data de nascimento da PessoaFisica");
            //Field(x => x.PessoaTipo, type: typeof(EnumerationGraphType<TipoPessoaEnum>)).Description("PessoaFisica possui obito?");
        }
    }
}
