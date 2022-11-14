using ReyMagoApi.Entities;

namespace ReyMagoAPI.Core.Interfaces
{
    public interface IGrimorioRepository
    {
        Task<IEnumerable<Grimorio>> GetGrimorios();
    }
}