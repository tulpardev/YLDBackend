using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Programming.API.Security
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionsRoles = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UsersDAL usersDAL = new UsersDAL();
            var user = usersDAL.GetUserByName(userName);
            if (user != null && actionsRoles.Contains(user.Role))
            {

            }

            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}