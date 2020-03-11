namespace FitnessApp.Controllers
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;

    public class PersonController : ApiController
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> res = new List<string>();
            foreach(var item in new PersonDataAccessController().Select())
                res.Add(JsonConvert.SerializeObject(item));
            return res;
        }

        // GET: api/Person/{id}
        [HttpGet]
        public string Get(int id)
        {
            Person res = new PersonDataAccessController().Select(id);
            if (res != null)
                return JsonConvert.SerializeObject(res);
            else return null;
        }

        // POST: api/Person
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Person value)
        {
            return new PersonDataAccessController().Insert(value) ? 
                new HttpResponseMessage(System.Net.HttpStatusCode.OK) : 
                    new HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);
        }

        // DELETE: api/Person/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            new PersonDataAccessController().Delete(id);
        }
    }
}
