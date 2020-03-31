namespace FitnessApp.Controllers
{
    using Models;
    using System.Web.Http;

    [Route("api/Login")]
    public class LogInCredentialsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]LogInCredentials value)
        {
            return Json(new LogInCredentialsDataAccessController().Select(value));
        }
    }
}
