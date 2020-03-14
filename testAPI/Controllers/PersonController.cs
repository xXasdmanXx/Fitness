namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class PersonController : ApiController
    {
        // GET: api/Person
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(new PersonDataAccessController().Select());
        }

        // GET: api/Person/{id}
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(new PersonDataAccessController().Select(id));
        }

        // POST: api/Person
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Person value)
        {
            return new PersonDataAccessController().Insert(value) ? 
                new HttpResponseMessage(HttpStatusCode.OK) : 
                    new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        }

        // DELETE: api/Person/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            new PersonDataAccessController().Delete(id);
        }
    }
}
