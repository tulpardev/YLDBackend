using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Programming.API.Controllers
{
    public class InputCoilController : ApiController
    {
        InputCoilDAL inputCoilDAL = new InputCoilDAL();

        [HttpGet]
        [Route("api/InputCoil")]
        public IHttpActionResult GetAllCoils()
        {
            var allCoils = inputCoilDAL.GetAllCoils();
            return Ok(allCoils);
        }

        [HttpGet]
        [Route("homepage/api/InputCoil")]
        public IHttpActionResult GetCoilsForTables(int count, int size)
        {
            var result = inputCoilDAL.GetCoilsForTable(size, count);
            return Ok(result.ToList());
        }
    }
}
