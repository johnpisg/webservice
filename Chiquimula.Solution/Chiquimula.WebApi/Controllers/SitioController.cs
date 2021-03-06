﻿using Chiquimula.Data;
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
        public List<SitioDto> Get(string deviceUniqueId)
        {
            return new TourService().GetAllSitios(deviceUniqueId);
        }

        // GET: api/Sitio
        public List<SitioDto> GetTop(string deviceUniqueId, int number)
        {
            return new TourService().GetTopSitios(deviceUniqueId, number);
        }

        // GET: api/Sitio/5
        public SitioDto GetDetalleSitio(string deviceUniqueId, int id)
        {
            return new TourService().GetSitioById(deviceUniqueId, id); 
        }

        // POST: api/Sitio
        public RankDto PostAddRanking([FromBody]RankDto rankObject)
        {
            //rankear
            return new TourService().Rankear(rankObject);
        }
        
    }
}
