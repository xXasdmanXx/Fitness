namespace FitnessApp.Controllers
{
    using System.Web.Http;

    public class AllExerciseController : ApiController
    {
        [Route("api/Person/GpsExercise/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(new GpsExerciseDataAccessController().SelectAll(id));
        }
    }
}
