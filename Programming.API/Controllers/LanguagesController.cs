using Programming.DAL;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
//using System.Web.Http.Cors;

namespace Programming.API.Controllers
{
    [Authorize]
    
    //[EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class LanguagesController : ApiController
    {
        
        LanguagesDAL languagesDAL = new LanguagesDAL();

        //kullanıcı rolü A ise çalışcak
        [ResponseType(typeof(IEnumerable<Languages>))]

        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var languages = languagesDAL.GetAllLanguages();
            return Ok(languages);
        }

        //kullanıcı rolü A veya B ise çalışacak.
        [ResponseType(typeof(Languages))]
        //[ApiAuthorizeAttribute(Roles = "A,U")]
        public IHttpActionResult Get(int id)
        {
            var languages = languagesDAL.GetLanguagesById(id);
            if (languages == null)
            {
                return NotFound();
            }

            return Ok(languages);
        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Post(Languages language)
        {
            if (ModelState.IsValid)
            {
                var createdLanguage = languagesDAL.CreateLanguage(language);
                return CreatedAtRoute("DefaultApi", new { id = createdLanguage.ID }, createdLanguage);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [ResponseType(typeof(Languages))]
        public IHttpActionResult Put(int id, Languages language)
        {

            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            else
            {
                return Ok(languagesDAL.UpdateLanguage(id, language));
            }
        }

        public IHttpActionResult Delete(int id)
        {
            if (languagesDAL.IsThereAnyLanguage(id) == false)
            {
                return NotFound();
            }
            else
            {
                languagesDAL.DeleteLanguage(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
