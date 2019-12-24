using GraphQL.Types;
using POC.GraphQL.Types;
using POC.Model.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POC.GraphQL
{
    public class TestQuery : ObjectGraphType<object>
    {
        public TestQuery()
        {
            Field<ListGraphType<PessoaFisicaType>>("pessoafisica",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="nome"},
                    new QueryArgument<ListGraphType<TelefoneType>>{Name="telefone"}

                }),                
                resolve: contexto =>
                {
                    var pessoasFisicas = DataGenerator.GeneratePessoaFisica();
                    var nome = contexto.GetArgument<string>("nome");
                    if (!string.IsNullOrWhiteSpace(nome))
                        return pessoasFisicas.Where(x => x.Nome == nome);
                    return pessoasFisicas;
                }

                );

            Field<ListGraphType<TelefoneType>>("telefone",
               arguments: new QueryArguments(new QueryArgument[]
               {
                   new QueryArgument<IdGraphType>{Name="id"},
                   new QueryArgument<StringGraphType>{Name="ddd"}

               }),
               resolve: contexto =>
               {
                   return DataGenerator.GenerateTelefone();
               }

               );
        }
    }
}
