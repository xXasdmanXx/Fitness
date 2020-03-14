namespace FitnessApp.Controllers
{
    using Models;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MealController : ApiController
    {
        // GET: api/Meal
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> res = new List<string>();
            foreach (var item in new MealDataAccessController().Select())
                res.Add(JsonConvert.SerializeObject(item));
            return res;
        }

        // GET: api/Meal/5
        [HttpGet]
        public string Get(int id)
        {
            Meal res = new MealDataAccessController().Select(id);
            if (res != null)
                return JsonConvert.SerializeObject(res);
            else return null;
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
