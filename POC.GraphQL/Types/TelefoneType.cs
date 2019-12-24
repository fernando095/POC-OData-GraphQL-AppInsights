using GraphQL.Types;
using POC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.GraphQL.Types
{
    public class TelefoneType : ObjectGraphType<Telefone>
    {
        public TelefoneType()
        {
            Name = "Telefone";
            Field(x => x.ID, type: typeof(IdGraphType)).Description("ID do Telefone");
            Field(x => x.DDD).Description("DDD do Telefone");
            Field(x => x.Numero).Description("Numero do Telefone");
        }
    }
}
