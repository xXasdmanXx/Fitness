namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Web.Http;

    public class GpsExerciseController : ApiController
    {
        /*// GET: api/GpsExercise
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GpsExercise/5
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/GpsExercise
        [HttpPost]
        public IHttpActionResult Post([FromBody]GpsExercise value)
        {
            return Content(HttpStatusCode.OK, new GpsExerciseDataAccessController().Insert(value));
        }

        /*// DELETE: api/GpsExercise/5
        public void Delete(int id)
        {
        }*/
    }
}
