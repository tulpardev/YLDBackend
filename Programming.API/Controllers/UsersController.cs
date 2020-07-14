using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Programming.DAL;

namespace Programming.API.Controllers
{
    public class UsersController : ApiController
    {
        //private ProgrammingDbEntities db = new ProgrammingDbEntities();
        UsersDAL usersDAL = new UsersDAL();

        // GET: api/Users
        [ResponseType(typeof(IEnumerable<Users>))]
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            var users = usersDAL.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users userModel)
        {
            if (ModelState.IsValid)
            {
                var checkUserName = usersDAL.CheckUserByName(userModel);
                if(checkUserName == false)
                {
                    var createdUser = usersDAL.CreateUser(userModel);
                    return CreatedAtRoute("DefaultApi", new { id = createdUser.UserId }, createdUser);
                }
                return Ok("Kullanıcı adı mevcut");               
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/users/login")]
        public IHttpActionResult PostUsersByGet(Users user)
        {
            var isLoggin = usersDAL.LoginCheck(user);
            if (isLoggin != "false")
            {
                //return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
                return Ok(isLoggin);
            }
            else
            {
                return Content(HttpStatusCode.Unauthorized,"Kullanıcı adı veya Şifre yanlış");
            }
        }

        //// GET: api/Users/5
        //[ResponseType(typeof(Users))]
        //public IHttpActionResult GetUsers(int id)
        //{
        //    Users users = db.Users.Find(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}

        //// PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUsers(int id, Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != users.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(users).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
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

        // POST: api/Users


        //// DELETE: api/Users/5
        //[ResponseType(typeof(Users))]
        //public IHttpActionResult DeleteUsers(int id)
        //{
        //    Users users = db.Users.Find(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(users);
        //    db.SaveChanges();

        //    return Ok(users);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UsersExists(int id)
        //{
        //    return db.Users.Count(e => e.UserId == id) > 0;
        //}
    }
}