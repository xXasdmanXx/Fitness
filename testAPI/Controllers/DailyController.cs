namespace FitnessApp.Controllers
{
    using Models;
    using System.Web.Http;

    public class DailyController : ApiController
    {
        // POST: api/Daily
        [HttpPost]
        public IHttpActionResult Post([FromBody]Daily value)
        {
            return Json(new DailyDataAccessController().Select(value));
        }
    }
}
