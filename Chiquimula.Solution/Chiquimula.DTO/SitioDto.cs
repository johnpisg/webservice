using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiquimula.DTO
{
    public class SitioDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public double ranking { get; set; }
        public Nullable<int> imagenId { get; set; }
        public string horario { get; set; }
        public double precio { get; set; }
        public string info { get; set; }
        public string datos { get; set; }
        public string masdatos { get; set; }
        public decimal longitud { get; set; }
        public decimal latitud { get; set; }
        public List<string> imagenes { get; set; }
        public List<string> videos { get; set; }
    }
}
