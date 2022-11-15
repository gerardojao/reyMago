

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReyMagoApi.Core.Helper;
using ReyMagoApi.DataAccess;
using ReyMagoApi.Entities;
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
          return await _context.SolicitudIngresos
                .Include(a => a.Afinidad) 
                .Include(g=>g.Grimorio)
                .ToListAsync();           

        }
        public async Task<SolicitudIngreso> GetSolicitud(int id)
        {
            return await _context.SolicitudIngresos
                .Include(a => a.Afinidad)
                .Include(g => g.Grimorio)
                .FirstOrDefaultAsync(x => x.Id == id);           
        }
        public async Task<IEnumerable<SolicitudIngreso>> GetSolicitudesByGrimorio(string name)
        {
                      
               var grim =  await (from grimorio in _context.Grimorios
                            join solicitud in _context.SolicitudIngresos on grimorio.Id equals solicitud.Grimorio_Id
                            where grimorio.Name == name
                              select new SolicitudIngreso
                              {
                                  Id = solicitud.Id,
                                  Nombre = solicitud.Nombre + " " + solicitud.Apellido,
                                  Identificacion = solicitud.Identificacion
                              }).ToListAsync();
            
            return grim;

        }
        public async Task InsertSolicitud(SolicitudIngreso solicitudIngreso)
        {
            _context.SolicitudIngresos.Add(solicitudIngreso);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEstatusSolicitud(SolicitudIngreso solicitudIngreso)
        {
            var solicitud = await GetSolicitud(solicitudIngreso.Id);
            if (solicitud != null)
            {                
                solicitud.Estatus = solicitudIngreso.Estatus;

                if (solicitud.Estatus != false)
                {
                    Random rnd = new();
                    int number = rnd.Next(1, _context.Grimorios.Count());

                    solicitud.Grimorio_Id = number;

                    int row = await _context.SaveChangesAsync();
                    return row > 0;
                }               
            }
            return false;

        }
        public async Task<bool> UpdateSolicitud(int id, SolicitudIngreso solicitudIngreso)
        {
            var solicitud = await GetSolicitud(id);
            if (solicitud != null)
            {
                if(solicitudIngreso.Nombre != null) solicitud.Nombre = solicitudIngreso.Nombre;
                if (solicitudIngreso.Identificacion != null) solicitud.Apellido = solicitudIngreso.Apellido;
                solicitud.Edad = solicitudIngreso.Edad;
                if (solicitudIngreso.Nombre != null) solicitud.Nombre = solicitudIngreso.Nombre;
                if (solicitudIngreso.Afinidad_Id != null) solicitud.Afinidad_Id = solicitudIngreso.Afinidad_Id;

                int row = await _context.SaveChangesAsync();
                return row > 0;
            }
           
            return false;

        }

        public async Task<bool> DeleteSolicitud(int id)
        {
            var solicitud = await GetSolicitud(id);
            if(solicitud != null)
            {
                _context.SolicitudIngresos.Remove(solicitud);               
                int row = await _context.SaveChangesAsync();
                return row > 0;
            }
            return false;             
        }



    }
}
