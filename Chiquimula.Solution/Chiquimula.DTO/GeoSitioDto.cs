using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.DTO
{
    public class GeoSitioDto : SitioDto
    {
        public decimal DistanciaKm { get; set; }
    }

    public class GeoFiltroDto
    {
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public float RadioKm { get; set; }
        public string DeviceId { get; set; }
    }
}
