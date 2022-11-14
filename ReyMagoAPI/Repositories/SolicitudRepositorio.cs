using ApiBase.Models;
using Microsoft.EntityFrameworkCore;
using ReyMagoApi.DataAccess;
using ReyMagoAPI.Core.Interfaces;
using ReyMagoAPI.Entities;

namespace ReyMagoAPI.Repositories
{
    public class SolicitudRepositorio : ISolicitudIngresoRepository
    {
        public readonly AppDbContext _context;

        public SolicitudRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SolicitudIngreso>> GetSolicitudes()
        {
            return await _context.SolicitudIngresos.ToListAsync();
        }
        public async Task<IEnumerable<SolicitudIngreso>> GetSolicitudesByGrimorio(string name)
        {
            Respuesta<object> respuesta = new();

            //var grim = new List<SolicitudIngreso>();
            
            
               var grim =  (from grimorio in _context.Grimorios
                              from solicitud in _context.SolicitudIngresos
                              where grimorio.Name == name
                              select new SolicitudIngreso
                              {
                                  Id = solicitud.Id,
                                  Nombre = solicitud.Nombre + " " + solicitud.Apellido,
                                  Identificacion = solicitud.Identificacion
                              }).ToList();
            
            return grim;

        }
        public async Task InsertSolicitud(SolicitudIngreso solicitudIngreso)
        {
            _context.SolicitudIngresos.Add(solicitudIngreso);
            await _context.SaveChangesAsync();
        }

    }
}
