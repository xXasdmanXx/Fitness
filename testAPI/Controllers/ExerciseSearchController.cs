namespace FitnessApp.Controllers
{
    using Models;
    using System.Web.Http;

    [Route("api/Search/Exercise")]
    public class ExerciseSearchController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]Search value)
        {
            return Json(new ExerciseSearchDataAccessController().Select(value));
        }
    }
}
