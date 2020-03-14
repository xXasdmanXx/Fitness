namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class MealController : ApiController
    {
        // GET: api/Meal
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(new MealDataAccessController().Select());
        }

        // GET: api/Meal/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(new MealDataAccessController().Select(id));
        }

        // POST: api/Meal
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Meal value)
        {
            return new MealDataAccessController().Insert(value) ?
                new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        }

        // DELETE: api/Meal/5
        [HttpDelete]
        public void Delete(int id)
        {
            new MealDataAccessController().Delete(id);
        }
    }
}
