using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.GraphQL;

namespace POC.OdataVsGraphQL.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLTestController : ControllerBase
    {
        private readonly TestSchema _schema;

        public GraphQLTestController(TestSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> PostAll([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();
            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);


            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

    }
}