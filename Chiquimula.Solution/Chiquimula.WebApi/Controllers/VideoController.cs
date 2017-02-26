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
    public class VideoController : ApiController
    {
        // GET: api/Video
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Video/5
        public SitioVideosDto Get(int id)
        {
            return new TourService().GetVideosUrlBySitioId(id);
        }

        // POST: api/Video
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Video/5
        public void Delete(int id)
        {
        }
    }
}
