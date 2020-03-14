namespace FitnessApp.Controllers
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ExerciseController : ApiController
    {
        // GET: api/Exercise
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> res = new List<string>();
            foreach (var item in new ExerciseDataAccessController().Select())
                res.Add(JsonConvert.SerializeObject(item));
            return res;
        }

        // GET: api/Exercise/5
        [HttpGet]
        public string Get(int id)
        {
            Exercise res = new ExerciseDataAccessController().Select(id);
            if (res != null)
                return JsonConvert.SerializeObject(res);
            else return null;
        }

        // POST: api/Exercise
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Exercise value)
        {
            return new ExerciseDataAccessController().Insert(value) ?
                new HttpResponseMessage(HttpStatusCode.OK) :
                    new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
        }

        // DELETE: api/Exercise/5
        [HttpDelete]
        public void Delete(int id)
        {
            new ExerciseDataAccessController().Delete(id);
        }
    }
}
