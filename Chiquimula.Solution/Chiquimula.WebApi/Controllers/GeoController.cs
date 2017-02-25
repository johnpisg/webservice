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
    public class GeoController : ApiController
    {
        // GET: api/Geo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Geo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Geo
        public List<GeoSitioDto> Post([FromBody]GeoFiltroDto ubicacion)
        {
            return new TourService().GetSitiosCercanos(ubicacion.DeviceId, ubicacion.Latitud, ubicacion.Longitud, ubicacion.RadioKm);
        }

        // PUT: api/Geo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Geo/5
        public void Delete(int id)
        {
        }
    }
}
