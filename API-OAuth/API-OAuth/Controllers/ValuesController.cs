﻿using System.Collections.Generic;
using System.Web.Http;

namespace API_OAuth.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public void UseTest([FromBody]Use obj)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



    }

    public class Use
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
