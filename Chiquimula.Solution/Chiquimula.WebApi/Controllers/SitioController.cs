using Chiquimula.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chiquimula.WebApi.Controllers
{
    public class SitioController : ApiController
    {
        // GET: api/Sitio
        public List<Sitio> Get()
        {
            return new TourService().GetAllSitios();
        }

        // GET: api/Sitio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sitio
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sitio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sitio/5
        public void Delete(int id)
        {
        }
    }
}
