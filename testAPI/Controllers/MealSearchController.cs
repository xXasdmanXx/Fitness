namespace FitnessApp.Controllers
{
    using Models;
    using System.Web.Http;

    [Route("api/Search/Meal")]
    public class MealSearchController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody]Search value)
        {
            return Json(new MealSearchDataAccessController().Select(value));
        }
    }
}
