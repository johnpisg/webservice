using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.Data
{
    public class TourService
    {
        public List<Sitio> GetAllSitios()
        {
            var lista = new List<Sitio>();
            using (var db = new TourEntities())
            {
                lista = (from s in db.Sitio
                         select s).ToList();
            }
            return lista;
        }
    }
}
