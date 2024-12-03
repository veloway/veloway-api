

namespace Core.DTOs
{
    public class EnvioDTO
    {
        public long NroSeguimiento { get; set; }

        public string Descripcion { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public decimal PesoGramos { get; set; }

        public string UsuarioNombre { get; set; } = null!; 
        public string EstadoNombre { get; set; } = null!;
        public DomicilioDTO Origen { get; set; } = null!;
        public DomicilioDTO Destino { get; set; } = null!;
    }
    
}
