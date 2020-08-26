using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Programming.API.Models;
using Programming.DAL;
using Programming.DAL.Utilities;
using static Programming.DAL.Utilities.ExpressionFilter;

namespace Programming.API.Controllers
{
    public class MSG_PROD_COILController : ApiController
    {
        ProducedCoilDAL producedCoilDAL = new ProducedCoilDAL();

        // GET: api/MSG_PROD_COIL
        [HttpGet]
        [Route("api/MSG_PROD_COIL")]
        public IHttpActionResult GetMSG_PROD_COIL()
        {
            var producedCoils = producedCoilDAL.GetProducedCoils();
            return Ok(producedCoils);
        }

        // GET: api/MSG_PROD_COIL/5
        [ResponseType(typeof(MSG_PROD_COIL))]
        [HttpGet]
        [Route("api/MSG_PROD_COIL")]
        public IHttpActionResult GetMSG_PROD_COIL(int id)
        {
            var producedCoil = producedCoilDAL.GetProducedCoilsById(id);
            if (producedCoil == null)
            {
                return NotFound();
            }

            return Ok(producedCoil);
        }
        

        [HttpGet]
        [Route("homepage/api/MSG_PROD_COIL")]
        public IHttpActionResult GetProdCoil(int count,int size )
        {
            var result = producedCoilDAL.GetProducedCoilForTable(size,count);
            return Ok(result.ToList());
        }

        [HttpGet]
        [Route("homepage/api/MSG_PROD_COIL")]
        public IHttpActionResult GetProdCoil(int Id)
        {
            var result = producedCoilDAL.GetProducedCoilFieldsById(Id);
            return Ok(result.ToList());
        }

        [HttpPut]
        [Route("homepage/api/MSG_PROD_COIL")]
        public IHttpActionResult Put(int id, MSG_PROD_COIL mSG_PROD_COIL)
        {

            if (producedCoilDAL.IsThereAnyMsgCounter(id) == false)
            {
                return NotFound();
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            else
            {
                var res = producedCoilDAL.UpdateProducedCoilsFields(id, mSG_PROD_COIL);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
               
            }
        }

      

        [HttpPost]
        [Route("homepage/api/MSG_PROD_COIL")]
        public IHttpActionResult GetProducedCoilByFilter(Pagination pagination)
        {
            var item = producedCoilDAL.GetProducedCoilWithFilter(pagination.FilterQuery);
            return Ok(item);
        }

    }
}








//// GET: api/MSG_PROD_COIL/5
//[ResponseType(typeof(MSG_PROD_COIL))]
//public IHttpActionResult GetMSG_PROD_COIL(int id)
//{
//    MSG_PROD_COIL mSG_PROD_COIL = db.MSG_PROD_COIL.Find(id);
//    if (mSG_PROD_COIL == null)
//    {
//        return NotFound();
//    }

//    return Ok(mSG_PROD_COIL);
//}

//// PUT: api/MSG_PROD_COIL/5
//[ResponseType(typeof(void))]
//public IHttpActionResult PutMSG_PROD_COIL(int id, MSG_PROD_COIL mSG_PROD_COIL)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    if (id != mSG_PROD_COIL.MSG_COUNTER)
//    {
//        return BadRequest();
//    }

//    db.Entry(mSG_PROD_COIL).State = EntityState.Modified;

//    try
//    {
//        db.SaveChanges();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!MSG_PROD_COILExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return StatusCode(HttpStatusCode.NoContent);
//}

//// POST: api/MSG_PROD_COIL
//[ResponseType(typeof(MSG_PROD_COIL))]
//public IHttpActionResult PostMSG_PROD_COIL(MSG_PROD_COIL mSG_PROD_COIL)
//{
//    if (!ModelState.IsValid)
//    {
//        return BadRequest(ModelState);
//    }

//    db.MSG_PROD_COIL.Add(mSG_PROD_COIL);

//    try
//    {
//        db.SaveChanges();
//    }
//    catch (DbUpdateException)
//    {
//        if (MSG_PROD_COILExists(mSG_PROD_COIL.MSG_COUNTER))
//        {
//            return Conflict();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return CreatedAtRoute("DefaultApi", new { id = mSG_PROD_COIL.MSG_COUNTER }, mSG_PROD_COIL);
//}

//// DELETE: api/MSG_PROD_COIL/5
//[ResponseType(typeof(MSG_PROD_COIL))]
//public IHttpActionResult DeleteMSG_PROD_COIL(int id)
//{
//    MSG_PROD_COIL mSG_PROD_COIL = db.MSG_PROD_COIL.Find(id);
//    if (mSG_PROD_COIL == null)
//    {
//        return NotFound();
//    }

//    db.MSG_PROD_COIL.Remove(mSG_PROD_COIL);
//    db.SaveChanges();

//    return Ok(mSG_PROD_COIL);
//}

//protected override void Dispose(bool disposing)
//{
//    if (disposing)
//    {
//        db.Dispose();
//    }
//    base.Dispose(disposing);
//}

//private bool MSG_PROD_COILExists(int id)
//{
//    return db.MSG_PROD_COIL.Count(e => e.MSG_COUNTER == id) > 0;
//}