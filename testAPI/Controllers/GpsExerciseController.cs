namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Web.Http;

    public class GpsExerciseController : ApiController
    {
        // GET: api/GpsExercise/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(new GpsExerciseDataAccessController().Select(id));
        }
        
        // POST: api/GpsExercise
        [HttpPost]
        public IHttpActionResult Post([FromBody]GpsExercise value)
        {
            return Content(HttpStatusCode.OK, new GpsExerciseDataAccessController().Insert(value));
        }

        // DELETE: api/GpsExercise/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return (new GpsExerciseDataAccessController().Delete(id) ? Content(HttpStatusCode.OK, 1) : Content(HttpStatusCode.NotFound, 0));
        }
    }
}
