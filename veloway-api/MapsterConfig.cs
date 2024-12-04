using Core.DTOs;
using Data.Models;
using Mapster;

namespace veloway_api
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            // Mapeo de Envio a EnvioDTO
            TypeAdapterConfig<Envio, EnvioDTO>.NewConfig()
                .Map(dest => dest.UsuarioNombre, src => src.IdClienteNavigation.Nombre)
                .Map(dest => dest.EstadoNombre, src => src.IdEstadoNavigation.Nombre)
                .Map(dest => dest.Origen, src => src.IdOrigenNavigation.Adapt<DomicilioDTO>())
                .Map(dest => dest.Destino, src => src.IdDestinoNavigation.Adapt<DomicilioDTO>());

            // Mapeo de Domicilio a DomicilioDTO
            TypeAdapterConfig<Domicilio, DomicilioDTO>.NewConfig();
        }
    }
}
