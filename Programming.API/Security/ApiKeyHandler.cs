using Programming.DAL;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Programming.API.Security
{
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var queryString = request.RequestUri.ParseQueryString(); // Query string den api key aldık.
            //var apiKey = queryString["apiKey"];

            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
            UsersDAL usersDAL = new UsersDAL();
            var user = usersDAL.GetUserByApiKey(apiKey);
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "ApiKey")); // bir princable objesi oluştur ve sistemi kullanan user a bu princible objesini ata.
                HttpContext.Current.User = principal; // current user bu princable objesini at.
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}