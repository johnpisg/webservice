using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.DTO
{
    public class SitioVideosDto
    {
        public int SitioId { get; set; }
        public string SitioTitulo { get; set; }
        public List<string> Videos { get; set; }
    }
}
