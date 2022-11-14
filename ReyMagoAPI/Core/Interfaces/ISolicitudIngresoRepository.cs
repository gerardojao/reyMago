using Microsoft.Extensions.Hosting;
using ReyMagoAPI.Entities;

namespace ReyMagoAPI.Core.Interfaces
{
    public interface ISolicitudIngresoRepository
    {
        Task<IEnumerable<SolicitudIngreso>> GetSolicitudes();
        Task<IEnumerable<SolicitudIngreso>> GetSolicitudesByGrimorio(string name);
        Task InsertSolicitud(SolicitudIngreso solicitudIngreso);
    }
}