using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.GraphQL
{
    public class TestSchema : Schema
    {
        public TestSchema(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
            
            Query = serviceProvider.GetRequiredService<TestQuery>();

        }
    }
}
