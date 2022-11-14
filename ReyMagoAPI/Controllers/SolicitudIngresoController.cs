using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReyMagoAPI.Entities;
using ReyMagoApi.DataAccess;
using ReyMagoAPI.Core.Interfaces;
using ReyMagoAPI.Core.Models.DTO;
using AutoMapper;

namespace ReyMagoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudIngresoController : ControllerBase
    {

        private readonly ISolicitudIngresoRepository _solicitudRepository;
        private readonly IMapper _mapper;

        public SolicitudIngresoController(ISolicitudIngresoRepository solicitudRepository, IMapper mapper)
        {
            _solicitudRepository = solicitudRepository;
            _mapper = mapper;
        }

        // GET: api/SolicitudIngreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudIngreso>>> GetAllSolicitudes()
        {
            var solicitudes = await _solicitudRepository.GetSolicitudes();
            var solicitudesDto = _mapper.Map<IEnumerable<SolicitudIngresoDTO>>(solicitudes);
            return Ok(solicitudesDto);
        }

        // GET: api/SolicitudIngreso/5
        [HttpGet("{name}")]
        public async Task<IActionResult> GetSolicitudIngreso(string name)
        {
            var solicitudIngreso = await _solicitudRepository.GetSolicitudesByGrimorio(name);

            if (solicitudIngreso == null)
            {
                return NotFound();
            }
            else
            {
                var grimDTO = _mapper.Map<IEnumerable<SolicitudIngresoPorGrimorioDTO>>(solicitudIngreso);
                return Ok(grimDTO);
            }

           
        }

        // PUT: api/SolicitudIngreso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudIngreso(int id, SolicitudIngresoDTO solicitudIngresoDto)
        {
            var solicitudIngreso = _mapper.Map<SolicitudIngreso>(solicitudIngresoDto);
            solicitudIngreso.Id = id;

            await _solicitudRepository.UpdateSolicitud(solicitudIngreso);
            return Ok(solicitudIngreso);
        }

        // POST: api/SolicitudIngreso
        [HttpPost]
        public async Task<ActionResult> PostSolicitudIngreso(SolicitudIngresoDTO solicitudIngreso)
        {
            var solicitud = _mapper.Map<SolicitudIngreso>(solicitudIngreso);
            await _solicitudRepository.InsertSolicitud(solicitud);           
            return Ok(solicitud);
        }

        // DELETE: api/SolicitudIngreso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitudIngreso(int id)
        {
            var result =  await _solicitudRepository.DeleteSolicitud(id);
            return Ok(result);
        }

        //private bool SolicitudIngresoExists(int id)
        //{
        //    return _context.SolicitudIngresos.Any(e => e.Id == id);
        //}
    }
}
