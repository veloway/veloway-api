using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class DomicilioDTO
    {
        public string Calle { get; set; } = null!;
        public int Numero { get; set; }
        public string? Depto { get; set; }
        public int? Piso { get; set; }
        public string? Descripcion { get; set; }
    }
}
