using Microsoft.AspNetCore.Mvc;
using ReyMagoAPI.Entities;

namespace ReyMagoAPI.Core.Interfaces
{
    public interface ISolicitudIngresoRepository
    {
        Task<IEnumerable<SolicitudIngreso>> GetSolicitudes();        
        Task<SolicitudIngreso> GetSolicitud(int id);
        Task<IEnumerable<SolicitudIngreso>> GetSolicitudesByGrimorio(string name);
        Task InsertSolicitud(SolicitudIngreso solicitudIngreso);
        Task<bool> UpdateSolicitud(int id, SolicitudIngreso solicitudIngreso);
        Task<bool> UpdateEstatusSolicitud(SolicitudIngreso solicitudIngreso);
        Task<bool> DeleteSolicitud(int id);
    }
}