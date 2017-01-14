using Chiquimula.Data;
using Chiquimula.DTO;
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
        public List<SitioDto> Get()
        {
            return new TourService().GetAllSitios();
        }

        // GET: api/Sitio/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sitio
        public RankDto PostAddRanking([FromBody]RankDto rankObject)
        {
            return new TourService().Rankear(rankObject);
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
