namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
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
        public IHttpActionResult Post([FromBody]Person value)
        {
            return Content(HttpStatusCode.OK, new PersonDataAccessController().Insert(value));
        }

        // DELETE: api/Person/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            new PersonDataAccessController().Delete(id);
        }
    }
}
