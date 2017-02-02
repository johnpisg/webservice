using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.DTO
{
    public class GeoSitioDto
    {
        public int SitioId { get; set; }
        public string SitioNombre { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public decimal DistanciaKm { get; set; }
    }
}
