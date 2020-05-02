namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Web.Http;

    public class ExerciseController : ApiController
    {
        // GET: api/Exercise
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(new ExerciseDataAccessController().Select());
        }

        // GET: api/Exercise/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(new ExerciseDataAccessController().Select(id));
        }

        // POST: api/Exercise
        [HttpPost]
        public IHttpActionResult Post([FromBody]Exercise value)
        {
            return new ExerciseDataAccessController().Insert(value) ?
                Content(HttpStatusCode.OK,1) :
                    Content(HttpStatusCode.ExpectationFailed,0);
        }

        // DELETE: api/Exercise/5
        [HttpDelete]
        public void Delete(int id)
        {
            new ExerciseDataAccessController().Delete(id);
        }
    }
}
