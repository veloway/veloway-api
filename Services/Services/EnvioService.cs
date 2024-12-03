using Data.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly VelowayDbContext db;
        public EnvioService(VelowayDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Envio>> getAll()
        {
            return await db.Envios.ToListAsync();
        }
    }
}
