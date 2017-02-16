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
    public class ComentarioController : ApiController
    {
        // GET: api/Comentario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comentario/5
        public List<ComentarioDto> Get(string deviceUniqueId, int id)
        {
            return new TourService().GetComentariosSitios(id);
        }

        // POST: api/Comentario
        public bool Post([FromBody]ComentarioDto comentario)
        {
            //Comentar
            return new TourService().Comentar(comentario);
        }

        // PUT: api/Comentario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comentario/5
        public void Delete(int id)
        {
        }
    }
}
