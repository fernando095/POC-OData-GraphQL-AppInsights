using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.Model;
using POC.Model.Generator;

namespace POC.OdataVsGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ODataApiController : ODataController
    {
        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<PessoaFisica> Get() {
            var a = DataGenerator.GeneratePessoaFisica();

            return a;
        }
    }
}