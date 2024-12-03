using Data.Models;

namespace Services.Interfaces
{
    public interface IEnvioService
    {
        Task<List<Envio>> getAll();
    }
}
