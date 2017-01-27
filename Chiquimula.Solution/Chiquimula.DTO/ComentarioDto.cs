using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.DTO
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Usuario { get; set; }
        public int sitioId { get; set; }
        public string deviceUniqueId { get; set; }
        public DateTime fecha { get; set; }
    }
}
